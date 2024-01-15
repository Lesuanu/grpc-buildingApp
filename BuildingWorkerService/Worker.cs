using BuildingServiceGrpc;
using Grpc.Net.Client;
using static BuildingServiceGrpc.BuildingProtoService;

namespace BuildingWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly BuildingFactory _factory;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, BuildingFactory factory, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                try
                {
                    using var channel = GrpcChannel.ForAddress("https://localhost:7071");
                    var client = new BuildingProtoServiceClient(channel);

                    _logger.LogInformation("AddBuilding started..");

                    var addBuilding = await client.AddBuildingAsync(await _factory.Generate());
                    _logger.LogInformation($"the building is ", addBuilding.ToString());
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw;
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}