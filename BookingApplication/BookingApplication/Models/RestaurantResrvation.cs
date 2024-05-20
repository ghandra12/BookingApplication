using System.ComponentModel.DataAnnotations;

namespace BookingApplication.Models
{
    public class RestaurantReservation
    {
        public Guid Id { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Guid UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string StartHour { get; set; }
    }
}
