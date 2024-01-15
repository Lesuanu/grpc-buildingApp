using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingSecurityBETA_Identity.Data
{
    public class BuildingIdentityContext : IdentityDbContext
    {
        public BuildingIdentityContext(DbContextOptions<BuildingIdentityContext> options) : base(options)
        {
            
        }
    }
}
