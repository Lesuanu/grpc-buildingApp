namespace BuildingBETA_Api
{
    public interface IBuildingDatabaseSetting
    {
        public string BuildingCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
