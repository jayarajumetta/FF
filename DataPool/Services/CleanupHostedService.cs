namespace DataPool.Services
{
    /// <summary>
    /// Runs on startup (and then every 24 hours) to:
    ///   1. Auto-release claims that have been held longer than StaleClaimedHours.
    ///   2. Delete consumed records older than ConsumedDaysOld days.
    ///
    /// Configure in DataPool/appsettings.json:
    ///   "Cleanup": { "ConsumedDaysOld": 30, "StaleClaimedHours": 48 }
    /// </summary>
    public class CleanupHostedService : BackgroundService
    {
        private readonly IDataPoolService _service;
        private readonly ILogger<CleanupHostedService> _logger;
        private readonly int _consumedDaysOld;
        private readonly int _staleClaimedHours;

        public CleanupHostedService(
            IDataPoolService service,
            ILogger<CleanupHostedService> logger,
            IConfiguration configuration)
        {
            _service           = service;
            _logger            = logger;
            _consumedDaysOld   = configuration.GetValue<int>("Cleanup:ConsumedDaysOld",   30);
            _staleClaimedHours = configuration.GetValue<int>("Cleanup:StaleClaimedHours", 48);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Immediate run on startup
            RunCleanup();

            // Then every 24 hours
            using var timer = new PeriodicTimer(TimeSpan.FromHours(24));
            while (await timer.WaitForNextTickAsync(stoppingToken))
                RunCleanup();
        }

        private void RunCleanup()
        {
            try
            {
                var (released, removed) = _service.CleanupOldRecords(_consumedDaysOld, _staleClaimedHours);
                if (released > 0 || removed > 0)
                    _logger.LogInformation(
                        "[DataPool Cleanup] Released {Released} stale claim(s) (>{Hours}h), removed {Removed} consumed record(s) (>{Days}d).",
                        released, _staleClaimedHours, removed, _consumedDaysOld);
                else
                    _logger.LogDebug("[DataPool Cleanup] Nothing to clean up.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[DataPool Cleanup] Error during scheduled cleanup.");
            }
        }
    }
}
