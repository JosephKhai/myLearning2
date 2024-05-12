using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using myLearning.Common.DataAccess.EFCore.Repositories;
using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.Entities;
using Microsoft.Data.SqlClient;
using myLearning.DataAccess.EFCore.IRepository;
using System.Linq.Dynamic.Core;

namespace myLearning.DataAccess.EFCore.Repositories
{
    public class CountryRepository : BaseRepository<Countries, myLearningDbContexts>, ICountryRepository
    {
        public CountryRepository(myLearningDbContexts dbContext) : base(dbContext)
        {
        }

        public async Task AddCounty(Countries newCountry)
        {

            var context = GetContext();

            // Begin a transaction asynchronously
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Mark the new city entity as added
                    context.Entry(newCountry).State = EntityState.Added;

                    // Save changes to the database asynchronously
                    await context.SaveChangesAsync();

                    // Commit the transaction if the changes are successfully saved
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if an error occurs
                    await transaction.RollbackAsync();

                    // Log the exception
                    Console.WriteLine(ex.ToString());

                    // Re-throw the exception to propagate it up the call stack
                    throw;
                }
            }
        }

        public async Task DeleteCountry(int Id)
        {
            var context = GetContext();

            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    var cityId = new SqlParameter("@Id", Id);

                    // Execute the stored procedure to delete the city entity
                    var result = await context.Database.ExecuteSqlRawAsync($"EXEC {StoreProcedureName.DeleteCountry} @Id", cityId);

                    // If the stored procedure execution is successful, commit the transaction
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // If an error occurs, rollback the transaction
                    await transaction.RollbackAsync();
                    Console.WriteLine(ex.ToString());
                    throw; // Re-throw the exception to propagate it up the call stack
                }
            }
        }

        public async Task<IEnumerable<Countries>> GetAllCountries()
        {
            var countries = await GetEntities().OrderBy(x => x.Name).ToListAsync();
            return countries;
        }

        public async Task<ApiResult<Countries>> GetPageResultAsync(
            int pageIndex,
            int pageSize,
            string sortColumn,
            string sortOrder,
            string filterColumn,
            string filterQuery)
        {
            var source = GetEntities();
            var count = await source.CountAsync();
            var data = await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

            return new ApiResult<Countries>(
                data,
                count,
                pageIndex,
                pageSize,
                sortColumn,
                sortOrder,
                filterColumn,
                filterQuery);
        }

        public async Task<Countries> GetCountryById(int Id)
        {
            return await GetEntities()
               .Where(country => country.Id == Id)
               .FirstOrDefaultAsync();
        }

        public async Task UpdateCountry(Countries updateCountry)
        {
            var context = GetContext();

            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Update the city entity
                    context.Countries.Update(updateCountry);
                    await context.SaveChangesAsync();

                    // Commit the transaction if all changes are successfully saved
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    // Rollback the transaction if an error occurs
                    await transaction.RollbackAsync();
                    Console.WriteLine(e.ToString());
                    throw; // Re-throw the exception to propagate it up the call stack
                }
            }
        }

        public bool IsDuplicateCountry(string countryId, string fieldName, string fieldValue)
        {
            var context = GetContext();

            //switch(fieldName)
            //{
            //    case "name":
            //        return context.Countries.Any(c => c.Name == fieldValue && c.Id != countryId);
            //    case "iso2":
            //        return context.Countries.Any(c => c.ISO2 == fieldValue && c.Id != countryId);
            //    case "is03":
            //        return context.Countries.Any(c => c.ISO3 == fieldValue && c.Id != countryId);
            //    default:
            //        return false;
            //} 

            //alternative approach using system.Linq.Dynamic.Core
            return (ApiResult<Countries>.IsValidProperty(fieldName, true)) ? context.Countries.Any(
                string.Format("{0} == @0 && Id != @1", fieldName),
                fieldValue,
                countryId)
                : false;

        }

        private bool CountryExists(int id)
        {
            var context = GetContext();

            return context.Countries.Any(e => e.Id == id);
        }
    }
}
