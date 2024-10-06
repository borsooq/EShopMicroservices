using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services
    .AddApplicationsServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiService();

var app = builder.Build();

//Configure http pipeline
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.Run();
