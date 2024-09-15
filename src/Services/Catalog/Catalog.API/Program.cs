var builder = WebApplication.CreateBuilder(args);

//Add DI
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();
app.MapCarter();

//Add HTTP request pipelines

app.Run();
