using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.Entities;
using OfficeOpenXml;
using System.Security;

namespace myLearningAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly myLearningDbContexts _dbContexts;
        private readonly IWebHostEnvironment _env;

        public SeedController(myLearningDbContexts dbContexts, IWebHostEnvironment env)
        {
            _dbContexts = dbContexts;
            _env = env;
        }


        [HttpGet]
        public async Task<ActionResult> Import()
        {
            if (!_env.IsDevelopment())
            {
                throw new SecurityException("Not Allowed");
            }

            var path = Path.Combine(_env.ContentRootPath, "Source/worldcities.xlsx");



            using var stream = System.IO.File.OpenRead(path);
            using var excelPackage = new ExcelPackage(stream);

            //get the first worksheet
            var worksheet = excelPackage.Workbook.Worksheets[0];

            //define how many rows we want to process
            var nEndRow = 50;//worksheet.Dimension.End.Row;

            //initialize the record counters
            var numberOfCountriesAdded = 0;
            var numberOfCitiesAdded = 0;


            //create a lookup dictionary containing all the countries already existing into the database
            //it will empty for the first run
            var countriesByName = _dbContexts.Countries
                .AsNoTracking()
                .ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);


            //iterate through all rows, skipping the first one
            for (int nRow = 2; nRow < nEndRow; nRow++)
            {
                var row = worksheet.Cells[nRow, 1, nRow, worksheet.Dimension.End.Column];

                var countryName = row[nRow, 5].GetValue<string>();
                var iso2 = row[nRow, 6].GetValue<string>();
                var iso3 = row[nRow, 7].GetValue<string>();

                //create the Countries entity and fill it with xlsx data
                var country = new Countries
                {
                    Name = countryName,
                    ISO2 = iso2,
                    ISO3 = iso3,
                };

                //skip this country if it already exists in the database
                if (!countriesByName.ContainsKey(countryName))
                {
                    //store the country in our lookup to retrieve its ID later on
                    countriesByName.Add(countryName, country);
                }else
                {
                    continue;
                }
                 

                //add the new country to the DB context
                await _dbContexts.Countries.AddAsync(country);
                numberOfCountriesAdded++;

 
            }

            //save all the countries into the Database
            await _dbContexts.SaveChangesAsync();


            //create a lookup dictionary
            //containing all the cities already existing into the database (it will be emplty on the frist run)
            var cities = _dbContexts.Cities
                .AsNoTracking()
                .ToDictionary(x => (
                    Name: x.Name,
                    Lat: x.Lat,
                    Lon: x.Lon,
                    CountryId: x.CountryId
                ));

            //iterate through all rows, skipping the first one
            for (int nRow = 2; nRow < nEndRow; nRow++)
            {
                var row = worksheet.Cells[nRow, 1, nRow, worksheet.Dimension.End.Column];

                var name = row[nRow, 1].GetValue<string>();
                var nameAscii = row[nRow, 2].GetValue<string>();
                var lat = row[nRow, 3].GetValue<decimal>();
                var lon = row[nRow, 4].GetValue<decimal>();
                var countryName = row[nRow, 5].GetValue<string>();

                //retrieve country Id by countryName
                var countryId = countriesByName[countryName].Id;

                //skip this city if it already exists in the database
                if (cities.ContainsKey((

                    Name: name,
                    Lat: lat,
                    Lon: lon,
                    CountryId: countryId
                    )))

                    continue;


                //create the city entity and fill it with xlsx data
                var city = new Cities
                {
                    Name = name,
                    Lat = lat,
                    Lon = lon,
                    CountryId = countryId
                };

                //add the new city to the Db Context
                _dbContexts.Cities.Add(city);
                numberOfCitiesAdded++;


                //save all the cities into the database
                 await _dbContexts.SaveChangesAsync();
                
            }

            return new JsonResult(new
            {
                Cities = numberOfCitiesAdded,
                Countries = numberOfCountriesAdded
            });

        }
    }
}
