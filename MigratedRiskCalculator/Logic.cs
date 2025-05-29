using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MigratedRiskCalculator;

public class Logic : IHostedService
{
    private readonly ILogger<Logic> _logger;
    private readonly IRiskCalculator _riskCalculator;

    public Logic(ILogger<Logic> logger, IRiskCalculator riskCalculator)
    {
        _logger = logger;
        _riskCalculator = riskCalculator;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.ServiceStartingUp(nameof(RiskCalculator));
        
        _riskCalculator.Start();
        
        _logger.ServiceStarted(nameof(RiskCalculator));
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.ServiceStopped(nameof(RiskCalculator));
        
        _riskCalculator.Stop();
        
        _logger.ServiceStopped(nameof(RiskCalculator));
        
        return Task.CompletedTask;
    }

}