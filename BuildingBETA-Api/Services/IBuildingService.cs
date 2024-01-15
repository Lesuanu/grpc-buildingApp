using BuildingBETA_Api.Models;

namespace BuildingBETA_Api.Services
{
    public interface IBuildingService
    {
        List<Building> Get();
        Building Get(string id);
        void Delete(string id);
        Building Create(Building building);
        void Update(Building building, string id);
    }
}
