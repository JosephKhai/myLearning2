using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using myLearning.Common.DataAccess.EFCore.Repositories;
using myLearning.Common.Entities;
using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.Entities;
using myLearning.Infrastructure.IRepositories;

namespace myLearning.DataAccess.EFCore.Repositories
{
    public class CityRepository : BaseRepository<Cities, myLearningDbContexts>, ICityRepository
    {
        public CityRepository(myLearningDbContexts dbContext) : base(dbContext)
        {
        }

        public async Task AddCity(Cities newCity, ContextSession session)
        {
            var context = GetContext(session);

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

        public async Task DeleteCity(int Id, ContextSession session)
        {
            var context = GetContext(session);

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

        public async Task<IEnumerable<Cities>> GetAllCities(ContextSession session)
        {
            var cities = await GetEntities(session).OrderBy(x => x.Id).ToListAsync();
            return cities;
        }

        public async Task<Cities> GetCityById(int cityId, ContextSession session)
        {
            return await GetEntities(session)
                .Where(city => city.Id == cityId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateCity(Cities updateCity, ContextSession session)
        {
            var context = GetContext(session);

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
    }
}
