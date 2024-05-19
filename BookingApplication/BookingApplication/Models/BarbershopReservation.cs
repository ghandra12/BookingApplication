using System.ComponentModel.DataAnnotations;

namespace BookingApplication.Models
{
    public class BarbershopReservation
    {
        public Guid Id { get; set; }
        public Barbershop? Barbershop { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string StartHour { get; set; }
    }
}
