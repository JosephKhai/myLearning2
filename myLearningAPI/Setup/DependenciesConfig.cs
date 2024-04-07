using MediatR;
using myLearning.Common.Infrastructure.IServices;
using myLearning.DataAccess.EFCore.Repositories;
using myLearning.DIContainer;
using myLearning.Infrastructure.IRepositories;
using myLearning.Infrastructure.IServices;
using myLearning.Services.Services;
using myLearningAPI.Identity;

namespace myLearningAPI.Setup
{
    public class DependenciesConfig
    {
        public static void ConfigurDependencies(IServiceCollection services, string myLearningConnection)
        {
            DIContainerExtension.Initialize(services, myLearningConnection);

            //can also add another services here

        
        }
    }
}
