using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using myLearning.Common.DataAccess.EFCore.Repositories;
using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.DataAccess.EFCore.IRepository;
using myLearning.Entities;

namespace myLearning.DataAccess.EFCore.Repositories
{
    public class CityRepository : BaseRepository<Cities, myLearningDbContexts>, ICityRepository
    {
        public CityRepository(myLearningDbContexts dbContext) : base(dbContext)
        {
        }

        public async Task AddCity(Cities newCity)
        {
            var context = GetContext();

            // Begin a transaction asynchronously
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Mark the new city entity as added
                    context.Entry(newCity).State = EntityState.Added;

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

        //working
        public async Task DeleteCity(int Id)
        {
            var context = GetContext();

            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    var cityId = new SqlParameter("@Id", Id);

                    // Execute the stored procedure to delete the city entity
                    var result = await context.Database.ExecuteSqlRawAsync($"EXEC {StoreProcedureName.DeleteCity} @Id", cityId);

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

        //working
        public async Task<IEnumerable<Cities>> GetAllCities()
        {
            var cities = await GetEntities().OrderBy(x => x.Id).ToListAsync();
            return cities;
        }


        //working
        public async Task<ApiResult<Cities>> GetPageResultAsync(
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

            return new ApiResult<Cities>(
                data,
                count,
                pageIndex,
                pageSize,
                sortColumn,
                sortOrder,
                filterColumn,
                filterQuery);
        }


        //working
        public async Task<Cities> GetCityById(int cityId)
        {
            return await GetEntities()
                .Where(city => city.Id == cityId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateCity(Cities updateCity)
        {
            var context = GetContext();

            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Update the city entity
                    context.Cities.Update(updateCity);
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

        public bool IsDuplicateCity(Cities city)
        {
            var context = GetContext();

  
             var result = context.Cities.Any(
                e => e.Name == city.Name &&
                e.Lat == city.Lat &&
                e.Lon == city.Lon &&
                e.CountryId == city.CountryId 
                );

            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CityExists(int id)
        {
            var context = GetContext();

            return context.Cities.Any(e => e.Id == id);
        }
    }
}
