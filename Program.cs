using EFCoreDemo.Data;
using EFCoreDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IClockService, ClockService>();
builder.Services.AddTransient<IDbService, DbService>();
builder.Services.AddDbContext<BloggingContext>(options => {
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("BloggingContext"), o => o.UseNodaTime())
        .UseSnakeCaseNamingConvention();
});

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
