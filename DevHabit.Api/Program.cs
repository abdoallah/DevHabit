using DevHabit.Api.Database;
using DevHabit.Api.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Fixing the syntax issues in the following line
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.DevHabit)
        );
});

builder.Services.AddOpenTelemetry()
    .ConfigureResource(res => res.AddService(builder.Environment.ApplicationName))
    .WithTracing(tracing => tracing
          .AddHttpClientInstrumentation()
          .AddAspNetCoreInstrumentation())
    .WithMetrics(metrics => metrics
         .AddHttpClientInstrumentation()
         .AddAspNetCoreInstrumentation()
         .AddRuntimeInstrumentation())
         .UseOtlpExporter();
builder.Logging.AddOpenTelemetry(options =>
{
    options.IncludeScopes = true;
    options.IncludeFormattedMessage = true;
    //options.IncludeFormattedMessage = true;
    //options.ParseStateValues = true;
    //options.AddOtlpExporter(otlpOptions =>
    //{
    //    otlpOptions.Endpoint = new Uri("http://localhost:4317");
    //    otlpOptions.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
    //});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    await app.MigrateDatabaseAsync()
        .ConfigureAwait(true);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
