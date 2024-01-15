using BuildingServiceGrpc;
using Microsoft.EntityFrameworkCore;

namespace BuildingServices.Models
{
    public class BuildingAddress
    {
        public int Id { get; set; }
        public string City { get; init; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public string? Region { get; set; } = string.Empty;

       // var product = _mapper.Map<Building>(request.Building);

       // _context.Buildings.Add(product);
         //   await _context.SaveChangesAsync();

       // var productModel = _mapper.Map<BuildingModel>(product);
         //   return productModel;
        
    }
}
