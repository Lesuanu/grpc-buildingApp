namespace BuildingServices.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string BuildingName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public BuildingStaus BuildingStaus { get; set; }
        public BuildingAddress BuildingAddress { get; set; } = new BuildingAddress();
        public DateTime PurchaseDate { get; set; }
    }

    public enum BuildingStaus
    {
        Avaliable,
        NotAvaliable,
        ForSale,
        ForLease,
    }
             
}
