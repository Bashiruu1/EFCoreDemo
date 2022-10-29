using EFCoreDemo.Data.Contexts;
using EFCoreDemo.Data.Models;
using EFCoreDemo.GraphQL;
using EFCoreDemo.Services;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using static EFCoreDemo.GraphQL.Resolvers.Resolvers;

var builder = WebApplication.CreateBuilder(args);
var postgresDbSettings = builder.Configuration.GetSection(nameof(PostgresDbSettings)).Get<PostgresDbSettings>();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IClock>(SystemClock.Instance);
builder.Services.AddTransient<IDbService, DbService>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<BloggingContext>(options =>
{
    options
        .UseNpgsql(postgresDbSettings.ConnectionString, o =>
        {
            o.EnableRetryOnFailure();
        })
        .UseSnakeCaseNamingConvention();
}, ServiceLifetime.Transient);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<BlogType>()
    .AddType<PostType>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(ep =>
{
    ep.MapGraphQL();
});

app.Run();
