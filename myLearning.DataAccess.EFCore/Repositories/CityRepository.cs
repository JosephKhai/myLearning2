using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.Infrastructure.IRepositories;

namespace myLearning.DataAccess.EFCore.Repositories
{
    public class CityRepository : ICityRepository
    {
        private myLearningDbContexts myDbContext;

        public CityRepository(myLearningDbContexts myDbContext)
        {
            this.myDbContext = myDbContext;
        }
    }
}
