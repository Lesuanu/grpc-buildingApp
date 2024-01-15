using AutoMapper;
using BuildingServiceGrpc;
using BuildingServices.Infrastructure;
using BuildingServices.Models;
using Grpc.Core;

namespace BuildingServices.Services
{
    public class BuildinServices : BuildingProtoService.BuildingProtoServiceBase
    {
        private readonly ILogger _logger;
        private readonly BuildingContext _context;
        private readonly IMapper _mapper;
        public BuildinServices(ILogger<BuildinServices> logger, BuildingContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async override Task<BuildingModel> AddBuilding(AddBuildingRequest request, ServerCallContext context)
        {
            var product = _mapper.Map<Building>(request.Building);

            _context.Buildings.Add(product);
            await _context.SaveChangesAsync();

            var productModel = _mapper.Map<BuildingModel>(product);
            return productModel;
        }

    }
}
