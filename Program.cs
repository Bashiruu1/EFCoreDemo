using EFCoreDemo.Data.Contexts;
using EFCoreDemo.Data.Models;
using EFCoreDemo.Services;
using Microsoft.EntityFrameworkCore;
using NodaTime;

var builder = WebApplication.CreateBuilder(args);
var postgresDbSettings = builder.Configuration.GetSection(nameof(PostgresDbSettings)).Get<PostgresDbSettings>();

// Add services to the container.

builder.Services.AddControllers(options => {
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IClock>(SystemClock.Instance);
builder.Services.AddTransient<IDbService, DbService>();
builder.Services.AddDbContext<BloggingContext>(options => 
{
    options
        .UseNpgsql(postgresDbSettings.ConnectionString, o => o.UseNodaTime().EnableRetryOnFailure())
        .UseSnakeCaseNamingConvention();
}, ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
