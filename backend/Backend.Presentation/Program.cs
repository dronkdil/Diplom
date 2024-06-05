using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Storage.Blobs;
using Backend.Core;
using Backend.Core.UserContext;
using Backend.Domain.Responses.Base;
using Backend.Infrastructure;
using Backend.Presentation.Contexts;
using Backend.Presentation.Filters;
using Backend.Presentation.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ConfigurationManager>(_ => builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserContext, UserContext>();
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
builder.Services.AddSingleton(_ => new BlobServiceClient(builder.Configuration.GetConnectionString("StorageAccount")));

var app = builder.Build();
app.UseCors(policyBuilder => policyBuilder
    .WithOrigins("http://localhost:3000")
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod()
);
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = MediaTypeNames.Application.Json;

        var options = new JsonSerializerOptions();
        var enumConverter = new JsonStringEnumConverter();
        options.Converters.Add(enumConverter);
        await context.Response.WriteAsync(JsonSerializer.Serialize(Response.Failed("Server error"), options));
    });
});
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();