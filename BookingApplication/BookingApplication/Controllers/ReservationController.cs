using BookingApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApplication.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService ReservationService;
        public ReservationController(ReservationService ReservationService)
        {
            this.ReservationService = ReservationService;
        }
        public IActionResult Index()
        {
            var usr = this.User;
            Guid usId = Guid.Parse(usr.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value);

            var Reservations = ReservationService.GetAllReservations(usId);
            return View(Reservations);
        }
    }
}
