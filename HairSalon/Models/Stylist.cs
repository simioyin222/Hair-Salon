using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int StylistId { get; set; }
        public string Name { get; set; } = default!;
        public string Specialty { get; set; } = default!;
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}