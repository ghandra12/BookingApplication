using System.ComponentModel.DataAnnotations;

namespace BookingApplication.Models
{
    public class CinemaReservation
    {
        public Guid Id { get; set; }
        public Cinema Cinema { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string StartHour { get; set; }
    }
}
