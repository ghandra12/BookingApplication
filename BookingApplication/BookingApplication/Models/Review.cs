namespace BookingApplication.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Score {  get; set; }
        public int AccountId { get; set; }
        public int? CinemaId { get; set; }
        public int? RestaurantId { get; set; }
        public int? BarberShopId { get; set; }
        public int? HotelId { get; set; }
        public Account Account { get; set; } = null!;
        public Cinema? Cinema { get; set; } 
        public Restaurant? Restaurant { get; set; }
        public Hotel? Hotel { get; set; }
        public Barbershop? BarberShop { get; set; }
    }
}
