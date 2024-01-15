using BuildingServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BuildingServices.Infrastructure
{
    public class BuildingContext : DbContext
    { 
        
        public BuildingContext(DbContextOptions<BuildingContext> options) : base(options)
        {
            
        }
        public DbSet<Building> Buildings { get; set; }
        
    }
}
