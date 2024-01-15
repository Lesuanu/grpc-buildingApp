using BuildingServices.Models;

namespace BuildingServices.Infrastructure
{
    public class BuildingContextSeed
    {
        public static void Seeding(BuildingContext buildingContext)
        {
            if (!buildingContext.Buildings.Any())
            {
                var building = new List<Building>
                {
                    new Building
                    {
                        Id = 1,
                        BuildingName = "Residential",
                        Description = "spacious",
                        Price = 57_000_000,
                        BuildingStaus = BuildingStaus.Avaliable,
                        BuildingAddress = new BuildingAddress
                        {
                            Id = 1,
                            City = "Brooklyn",
                            State = "NY",
                            PhoneNumber = 453990,
                            Email = "amanda@gmail.com",
                            Street = "flower lane",
                            DateCreated = DateTime.Now,
                            Region = "Upper Region"
                        },
                        PurchaseDate = DateTime.UtcNow,
                    },

                    new Building
                    {
                        Id = 2,
                        BuildingName = "commercial",
                        Description = "spacious",
                        Price = 77_000_000,
                        BuildingStaus = BuildingStaus.ForLease,
                        BuildingAddress = new BuildingAddress
                        {
                            Id = 2,
                            City = "havana",
                            State = "CA",
                            PhoneNumber = 134879,
                            Email = "john@gmail.com",
                            Street = "pick up lane",
                            DateCreated = DateTime.Now,
                            Region = "lower Region"
                        },
                        PurchaseDate = DateTime.UtcNow,
                    }
                };
                buildingContext.Buildings.AddRange(building);
                buildingContext.SaveChangesAsync();
            }
        }
    }
}
