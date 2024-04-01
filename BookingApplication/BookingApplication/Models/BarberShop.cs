namespace BookingApplication.Models
{
    public class BarberShop
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public ICollection<Review>?  Reviews { get; set; }

    }
}
