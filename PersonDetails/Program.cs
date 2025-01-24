using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonDetails.Services;
using PersonDetails.Interfaces;
using PersonDetails.Models;
using PersonDetails.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.Configure<CsvSettings>(builder.Configuration.GetSection("CsvSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddScoped<CsvPersonRepository>();
builder.Services.AddScoped<MongoPersonRepository>();

builder.Services.AddScoped<IPersonService>(sp =>
{
    var csvRepo = sp.GetRequiredService<CsvPersonRepository>();
    var mongoRepo = sp.GetRequiredService<MongoPersonRepository>();
    return new PersonService(csvRepo, mongoRepo);
});


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // HTTP
    options.ListenAnyIP(8081, listenOptions =>
    {
        listenOptions.UseHttps("cert.pfx", "your_password");
    });
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy.WithOrigins("http://localhost:4444") // Add the origin you want to allow
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapOpenApi();
}
app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
