using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using TestPlatform.API.IAM.Application.Internal.CommandServices;
using TestPlatform.API.IAM.Application.Internal.QueryServices;
using TestPlatform.API.IAM.Domain.Repositories;
using TestPlatform.API.IAM.Domain.Services;
using TestPlatform.API.IAM.Infrastructure.Persistence.MongoDB.Repositories;
using TestPlatform.API.Shared.Domain.Repositories;
using TestPlatform.API.Shared.Infrastructure.Converters.JSON;
using TestPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Helpers;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Repositories;

// Create builder
var builder = WebApplication.CreateBuilder(args);

// Add relevant things about endpoints, controllers, and swagger
builder.Services.AddRouting(o => o.LowercaseUrls = true);
builder.Services.AddControllers(o => o.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

// Register MongoDB conventions for camel case naming
MongoFieldNamingHelper.UseCamelCaseNamingConvention();

// Add Cors policy to allow all origins, methods, and headers
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAllPolicy", p =>
        p.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Swagger/OpenAPI
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title       = "LiquoTrack.StocksipPlatform.API",
        Version     = "v1",
        Description = "StockSip Platform API",
        TermsOfService = new Uri("https://stocksip.com/tos"),
        Contact = new OpenApiContact { Name = "StockSip", Email = "contact@stocksip.com" },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url  = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        }
    });
    
    // Enable Annotations for Swagger
    o.EnableAnnotations();
});

// Dependency Injection

// Registers the value object mapping for all contexts
GlobalMongoMappingHelper.RegisterAllBoundedContextMappings();

// Registers the MongoDB client as a singleton service
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connectionString = config["MongoDB:ConnectionString"];
    return new MongoClient(connectionString);
});

// Add service por MongoDB client
builder.Services.AddSingleton<AppDbContext>();

// Bounded Context IAM
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();

// Bounded Context Shared
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new EmailJsonConverter());
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline for Swagger
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();