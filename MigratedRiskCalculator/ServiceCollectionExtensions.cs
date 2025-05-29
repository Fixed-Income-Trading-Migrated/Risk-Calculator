using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MigratedRiskCalculator.Data;
using NATS.Net;

namespace MigratedRiskCalculator;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupNats(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<NatsOptions>(configuration.GetSection(NatsOptions.SectionName));

        services.AddSingleton<NatsClient>(provider =>
        {
            var options = provider.GetRequiredService<IOptions<NatsOptions>>().Value;
            return new NatsClient(options.NatsUrl);
        });
        return services;
    }
    
    public static IServiceCollection SetupRiskCalculator(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IRiskCalculator, RiskCalculator>();
        services.AddHostedService<Logic>();
        return services;
    }
}