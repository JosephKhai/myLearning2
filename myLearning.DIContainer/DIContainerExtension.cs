using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myLearning.Common.Infrastructure;
using myLearning.Common.Infrastructure.IServices;
using myLearning.Common.WebApi;
using myLearning.DataAccess.EFCore;
using myLearning.DataAccess.EFCore.DbContexts;
using myLearning.DataAccess.EFCore.Repositories;
using myLearning.Infrastructure.IRepositories;
using myLearning.Infrastructure.IServices;
using myLearning.Services.Services;


namespace myLearning.DIContainer
{
    public static class DIContainerExtension
    {
        public static void Initialize(IServiceCollection services, string myLearningConnectionString)
        {
            services.AddDbContext<myLearningDbContexts>(options => options.UseSqlServer(myLearningConnectionString));
            //add other database context connection here


            //Add Database initialization
            //services.AddSingleton<ICurrentContextProvider, CurrentContextProvider>();
            services.AddScoped<IDataBaseInitializer, DatabaseInitializer>();



            //add IRepository and IServices here
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICityServices, CityService>();

            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICountryServices, CountryService>();


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
