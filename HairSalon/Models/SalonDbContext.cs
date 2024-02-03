using Microsoft.EntityFrameworkCore;
using HairSalon.Models;

namespace HairSalon.Models
{
    public class SalonDbContext : DbContext
    {
        public SalonDbContext(DbContextOptions<SalonDbContext> options) : base(options) { }

        public DbSet<Stylist> Stylists { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}