using CosmosDbRepositorySample.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCosmosRepository(options =>
{
    options.CosmosConnectionString = builder.Configuration["CosmosDbConnection"];
    options.DatabaseId = "RepsitorySampleDb";
    options.ContainerBuilder.Configure<Person>(q => q.WithContainer(nameof(Person) + "s").WithPartitionKey("/customer/id"));
    options.ContainerBuilder.Configure<Pet>(q => q.WithContainer(nameof(Pet) + "s").WithPartitionKey("/owner/id"));
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
