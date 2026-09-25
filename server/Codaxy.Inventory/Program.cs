using Codaxy.Inventory.Auth;
using Codaxy.Inventory.Setup;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddInventoryOptions(builder.Configuration)
    .AddInventoryPersistence(builder.Configuration)
    .AddInventoryDataProtection(builder.Configuration)
    .AddInventoryAuthentication(builder.Configuration)
    .AddInventoryHttpLogging()
    .AddHealthChecks();

var app = builder.Build();

app.MigrateAndSeed();

app.UseHttpLogging();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/health-check");
app.MapAuth();

// Every path the client routes to returns the shell; the API is under /api and answers for itself.
app.MapFallbackToFile("index.html");

app.Run();

public partial class Program;
