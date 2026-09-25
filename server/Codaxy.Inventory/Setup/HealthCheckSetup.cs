using Codaxy.Inventory.Persistence;

namespace Codaxy.Inventory.Setup;

public static class HealthCheckSetup
{
    /// <summary>
    /// Readiness covers the database, because an application that cannot reach it can answer nothing
    /// but the sign-in screen. Liveness carries no checks at all.
    /// </summary>
    public static IServiceCollection AddInventoryHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks().AddDbContextCheck<InventoryContext>("database");

        return services;
    }
}
