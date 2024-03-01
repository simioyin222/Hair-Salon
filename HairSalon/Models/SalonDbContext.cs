using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;

namespace HairSalon.Data
{
    public class SalonDbContext : IdentityDbContext<ApplicationUser>
    {
        public SalonDbContext(DbContextOptions<SalonDbContext> options)
            : base(options)
        {
        }

        public DbSet<Stylist> Stylists { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}