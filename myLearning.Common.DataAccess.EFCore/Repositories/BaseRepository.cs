using Microsoft.EntityFrameworkCore;
using myLearning.Common.Entities;

namespace myLearning.Common.DataAccess.EFCore.Repositories
{
    public class BaseRepository<TType, TContext> where TType : class, new()
        where TContext : CommonDbContext
    {
        protected readonly TContext DbContext;

        public BaseRepository(TContext dbContext)
        {
            DbContext = dbContext;
        }

        protected IQueryable<TType> GetEntities(ContextSession session)
        {
            var context = GetContext(session);
            return context.Set<TType>().AsQueryable().AsNoTracking();

        }

        protected TContext GetContext(ContextSession session)
        {
            DbContext.Session = session;
            return DbContext;
        }
    }
}
