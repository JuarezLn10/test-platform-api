using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Register MongoDB conventions for camel case naming
MongoFieldNamingHelper.UseCamelCaseNamingConvention();

// Add services to the container.

// Add service por MongoDB client
builder.Services.AddSingleton<AppDbContext>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();