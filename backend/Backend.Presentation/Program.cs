using Backend.Core;
using Backend.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore();
builder.Services.AddInfrastructure();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();