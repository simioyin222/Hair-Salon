using HairSalon.Models;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Data
{
    public class SalonDbContext : DbContext
    {
        public SalonDbContext(DbContextOptions<SalonDbContext> options) : base(options)
        {
        }

        public DbSet<Stylist> Stylists { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}