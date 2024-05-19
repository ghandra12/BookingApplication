namespace BookingApplication.Models
{
    public class Booking
    {
        public int Id { get; set; }  
        public DateTime BookingDate { get; set; }   
        public int AccountId { get; set; }
        public int? CinemaId {  get; set; }
        public int? RestaurantId { get; set; }
        public int? BarberShopId { get; set; }
        public Account Account { get; set; } = null!;
        public Cinema? Cinema { get; set; }
        public Restaurant? Restaurant { get; set; } 
        public Barbershop? BarberShop { get; set; }

    }
}
