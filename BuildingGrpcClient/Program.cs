// See https://aka.ms/new-console-template for more information
using BuildingServiceGrpc;
using Grpc.Net.Client;
using static BuildingServiceGrpc.BuildingProtoService;


using var channel = GrpcChannel.ForAddress("https://localhost:7071");
var client = new BuildingProtoService.BuildingProtoServiceClient(channel);


await AddBuildingAsync(client);

static async Task AddBuildingAsync(BuildingProtoServiceClient client)
{
    var response = client.AddBuilding(new AddBuildingRequest
    {
        Building = new BuildingModel
        {

        }
    });
}