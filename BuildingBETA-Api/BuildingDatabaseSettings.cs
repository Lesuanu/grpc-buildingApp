namespace BuildingBETA_Api
{
    public class BuildingDatabaseSettings : IBuildingDatabaseSetting
    {
        public string BuildingCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;    
        public string DatabaseName { get; set; } = string.Empty;    
    }
}
