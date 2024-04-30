using Microsoft.EntityFrameworkCore;
using myLearning.Common.Entities;

namespace myLearning.Common.DataAccess.EFCore.Repositories
{
    public class BaseRepository<TType, TContext> where TType : class, new()
        where TContext : CommonDbContextEntityState
    {
        protected readonly TContext DbContext;

        public BaseRepository(TContext dbContext)
        {
            DbContext = dbContext;
        }

        protected IQueryable<TType> GetEntities()
        {
            var context = GetContext();
            return context.Set<TType>().AsQueryable().AsNoTracking();

        }

        protected TContext GetContext()
        {
            return DbContext;
        }

        public async Task<IEnumerable<TType>> GetAllAsynce()
        {
            return await DbContext.Set<TType>().ToListAsync();
        }

        public async Task<TType> GetByIdAsync(int id)
        {
            return await DbContext.Set<TType>().FindAsync(id);
        }

        public async Task AddAsync(TType entity)
        {
            await DbContext.Set<TType>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TType entity)
        {
            DbContext.Set<TType>().Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if(entity != null)
            {
                DbContext.Set<TType>().Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }

        

    }
}
