using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using myLearning.Common.DataAccess.EFCore.Repositories;
using myLearning.Common.Entities;
using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.Entities;
using myLearning.Infrastructure.IRepositories;
using Microsoft.Data.SqlClient;

namespace myLearning.DataAccess.EFCore.Repositories
{
    public class CountryRepository : BaseRepository<Countries, myLearningDbContexts>, ICountryRepository
    {
        public CountryRepository(myLearningDbContexts dbContext) : base(dbContext)
        {
        }

        public async Task AddCounty(Countries newCountry, ContextSession session)
        {

            var context = GetContext(session);

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

        public async Task DeleteCountry(int Id, ContextSession session)
        {
            var context = GetContext(session);

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

        public async Task<IEnumerable<Countries>> GetAllCountries(ContextSession session)
        {
            var countries = await GetEntities(session).OrderBy(x => x.Id).ToListAsync();
            return countries;
        }

        public async Task<Countries> GetCountryById(int Id, ContextSession session)
        {
            return await GetEntities(session)
               .Where(country => country.Id == Id)
               .FirstOrDefaultAsync();
        }

        public async Task UpdateCountry(Countries updateCountry, ContextSession session)
        {
            var context = GetContext(session);

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
    }
}
