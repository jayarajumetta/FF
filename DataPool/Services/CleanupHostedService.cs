namespace DataPool.Services
{
    /// <summary>
    /// Runs on startup (and then every 24 hours) to:
    ///   1. Delete consumed records older than ConsumedDaysOld days.
    ///   2. Delete unclaimed (available) records older than AvailableDaysOld days.
    ///
    /// Claimed records are NEVER auto-released — only a manual Release action
    /// or a future automated process can return them to Available.
    ///
    /// Configure in DataPool/appsettings.json:
    ///   "Cleanup": { "ConsumedDaysOld": 30, "AvailableDaysOld": 90 }
    /// </summary>
    public class CleanupHostedService : BackgroundService
    {
        private readonly IDataPoolService _service;
        private readonly ILogger<CleanupHostedService> _logger;
        private readonly int _consumedDaysOld;
        private readonly int _availableDaysOld;

        public CleanupHostedService(
            IDataPoolService service,
            ILogger<CleanupHostedService> logger,
            IConfiguration configuration)
        {
            _service          = service;
            _logger           = logger;
            _consumedDaysOld  = configuration.GetValue<int>("Cleanup:ConsumedDaysOld",  30);
            _availableDaysOld = configuration.GetValue<int>("Cleanup:AvailableDaysOld", 90);
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
                var (removedConsumed, removedAvailable) = _service.CleanupOldRecords(_consumedDaysOld, _availableDaysOld);
                if (removedConsumed > 0 || removedAvailable > 0)
                    _logger.LogInformation(
                        "[DataPool Cleanup] Removed {Consumed} consumed record(s) (>{ConsumedDays}d), {Available} unclaimed record(s) (>{AvailableDays}d).",
                        removedConsumed, _consumedDaysOld, removedAvailable, _availableDaysOld);
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
