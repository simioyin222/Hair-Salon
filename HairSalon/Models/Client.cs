namespace HairSalon.Models
{
public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = default!;
        
        public int StylistId { get; set; }
        public Stylist Stylist { get; set; } = default!;
    }
}