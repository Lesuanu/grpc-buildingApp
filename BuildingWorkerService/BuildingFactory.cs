using BuildingServiceGrpc;
using BuildingServices.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingWorkerService
{
    public class BuildingFactory
    {
        public IConfiguration _configuration;
        public ILogger<BuildingFactory> _logger;    
        public BuildingFactory(ILogger<BuildingFactory> logger, IConfiguration configuration)
        {
            _logger = logger;   
            _configuration = configuration;
        }

        public Task<AddBuildingRequest> Generate()
        {
            var request = new AddBuildingRequest
            {
                Building = new BuildingModel
                {
                    Name = "steve",
                    Description = "it is a building",
                    Price = 30,
                    CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow),
                    BuildingAddress = new BuildingAddressModel
                    {
                        City = "NY",
                        State = "Brooklyn",
                        Phone = 2334_677,
                        Email = "ny@gmail.com",
                        CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow),
                    },
                    BuildingStatus = BuildingStatusModel.Available
                }

            };

            return Task.FromResult(request);
        }
    }
}
