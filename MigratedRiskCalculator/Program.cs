using Microsoft.Extensions.Hosting;
using MigratedRiskCalculator;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    services.SetupNats(context.Configuration);
    services.SetupRiskCalculator(context.Configuration);
});

var host = builder.Build();

await host.RunAsync();