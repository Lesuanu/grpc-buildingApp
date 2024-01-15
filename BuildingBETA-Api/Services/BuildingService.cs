using BuildingBETA_Api.Models;
using MongoDB.Driver;

namespace BuildingBETA_Api.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IMongoCollection<Building> _building;

        public BuildingService(IBuildingDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _building = database.GetCollection<Building>(setting.BuildingCollectionName);
        }
        
        public Building Create(Building building)
        {
            _building.InsertOne(building);
            return building;
        }
        
        public void Delete(string id)
        {
            _building.DeleteOne(building => building.Id == id);
        }

        public List<Building> Get()
        {
            return _building.Find(building => true).ToList();
        }

        public Building Get(string id)
        {
            return _building.Find(building => building.Id == id).FirstOrDefault();
        }

        public void Update(Building building, string id)
        {
            _building.ReplaceOne(building => building.Id == id, building);
        }
    }
    
}
