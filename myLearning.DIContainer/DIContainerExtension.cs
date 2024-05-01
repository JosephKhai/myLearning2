using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myLearning.Common.DataAccess.EFCore;
using myLearning.DataAccess.EFCore;
using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.DataAccess.EFCore.IRepository;
using myLearning.DataAccess.EFCore.Repositories;


namespace myLearning.DIContainer
{
    public static class DIContainerExtension
    {
        public static void Initialize(IServiceCollection services, string myLearningConnectionString)
        {
            services.AddDbContext<myLearningDbContexts>(options => options.UseSqlServer(myLearningConnectionString));
            //add other database context connection here

            //Add Database initialization
            services.AddScoped<IDataBaseInitializer, DatabaseInitializer>();

            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();



            /*
            AddSingleton - AddSingleton method create only one instance when the service is requested for first time. And then the same instance will be shared by all different http requests. 

           AddScoped - AddScoped method create single instance per request.
           For every individual request there will be a single instance or object.
           AddScoped method will make sure that Payment class instance will remain specific to a specific requestand will not be shared between multiple requests.


           AddTransient - AddTransient instance will not be shared at all even with in the same request.
           Every time a new instance will be created.

            */


        }
    }
}
