using Microsoft.EntityFrameworkCore;
using myLearning.Common.Infrastructure;
using myLearning.DataAccess.EFCore.DbContexts;

namespace myLearning.DataAccess.EFCore
{
    public class DatabaseInitializer : IDataBaseInitializer
    {
        private myLearningDbContexts _myLearningDbContexts;

        public DatabaseInitializer(myLearningDbContexts myLearningDbContexts)
        {
            _myLearningDbContexts = myLearningDbContexts;
        }

        public void Initialize()
        {
            using (_myLearningDbContexts)
            {
                _myLearningDbContexts.Database.SetCommandTimeout(System.TimeSpan.FromDays(1));
                _myLearningDbContexts.Database.Migrate();
            }

            //add many more database here
        }
    }
}
