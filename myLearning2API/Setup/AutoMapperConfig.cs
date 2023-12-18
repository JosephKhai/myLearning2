using AutoMapper.Configuration;
using myLearning.Infrastructure.Mapping;

namespace myLearning2API.Setup
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
