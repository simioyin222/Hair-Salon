using HairSalon.Models;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Data
{
    public class SalonDbContext : DbContext
    {
        public DbSet<Stylist> Stylists { get; set; } = default!;
        public DbSet<Client> Clients { get; set; } = default!;

        public SalonDbContext(DbContextOptions<SalonDbContext> options) : base(options)
        {
        }
    }
}