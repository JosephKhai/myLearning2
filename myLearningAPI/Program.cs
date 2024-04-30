using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using myLearningAPI.Setup;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from configuration
var myLearningConnectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
// Configure dependencies
DependenciesConfig.ConfigurDependencies(builder.Services, myLearningConnectionString);


//add httpcontext accessor
builder.Services.AddHttpContextAccessor();



// Add controllers and configure Swagger/OpenAPI
builder.Services.AddControllers();
    //.AddJsonOptions(option =>
    //{
    //    option.JsonSerializerOptions.WriteIndented = true;
    //});

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
