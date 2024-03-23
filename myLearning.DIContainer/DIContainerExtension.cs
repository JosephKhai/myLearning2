using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myLearning.Common.Infrastructure;
using myLearning.DataAccess.EFCore;
using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.DataAccess.EFCore.Repositories;
using myLearning.Infrastructure.IRepositories;

namespace myLearning.DIContainer
{
    public static class DIContainerExtension
    {
        public static void Initialize(IServiceCollection services, string myLearningConnectionString)
        {
            services.AddDbContext<myLearningDbContexts>(options => options.UseSqlServer(myLearningConnectionString
                ));

            //add other database context connection here


            //Add Database initialization
            services.AddScoped<IDataBaseInitializer, DatabaseInitializer>();


            //add IRepository and IServices here
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
        }
    }
}
