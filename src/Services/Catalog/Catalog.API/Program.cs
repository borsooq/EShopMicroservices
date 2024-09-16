using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

//Add DI
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

//Add HTTP request pipelines
app.MapCarter();

app.Run();
