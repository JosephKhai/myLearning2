using myLearning.DIContainer;

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
