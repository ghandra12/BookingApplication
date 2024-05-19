namespace BookingApplication.Models
{
    public class Barbershop
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public string? ImgPath { get; set; }
        public ICollection<Review>?  Reviews { get; set; }

    }
}
