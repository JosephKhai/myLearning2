using AutoMapper.Configuration;
using myLearning.Infrastructure.MappingProfiles;

namespace myLearningAPI.Setup
{
    public static class AutoMapperConfig
    {
        public static void Configure(MapperConfigurationExpression config)
        {
            config.AddProfile<SystemProfile>();

            //add many mapping profile here
        }
    }
}
