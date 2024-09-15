var builder = WebApplication.CreateBuilder(args);

//Add DI
var app = builder.Build();

//Add HTTP request pipelines

app.Run();
