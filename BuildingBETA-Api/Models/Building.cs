using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BuildingBETA_Api.Models
{
    public class Building
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("buildingName")]
        public string BuildingName { get; set; } = string.Empty;

        [BsonElement("buildingPrice")]
        public int BuildingPrice { get; set; }

        [BsonElement("buildingAgent")]
        public string BuildingAgent { get; set; } = string.Empty;

        [BsonElement("buildingLocation")]
        public string BuildingLocation { get; set; } = string.Empty;

        [BsonElement("purchaseDate")]
        public DateTime DatePurchased { get; set; }
    }
}
