using System.Text.Json.Serialization;
using Backend.Core;
using Backend.Infrastructure;
using Backend.Presentation.Filters;
using Backend.Presentation.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ConfigurationManager>(_ => builder.Configuration);
builder.Services.AddCore();
builder.Services.AddInfrastructure();
builder.Services.AddConfiguredAuthentication();
builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ResponseFilter>();
    })
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfiguredSwagger();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
app.Run();