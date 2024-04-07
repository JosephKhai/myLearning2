using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myLearning.Common.Infrastructure.IServices;
using myLearningAPI.Identity;
using myLearningAPI.Setup;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from configuration
var myLearningConnectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
// Configure dependencies
DependenciesConfig.ConfigurDependencies(builder.Services, myLearningConnectionString);

//configuration for Mapper
var config = new AutoMapper.Configuration.MapperConfigurationExpression();
AutoMapperConfig.Configure(config);
AutoMapper.Mapper.Initialize(config); //don't forget to initialize


//add httpcontext accessor
builder.Services.AddHttpContextAccessor();
// Register ICurrentContextProvider
builder.Services.AddSingleton<ICurrentContextProvider, CurrentContextProvider>();



// Add controllers and configure Swagger/OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
