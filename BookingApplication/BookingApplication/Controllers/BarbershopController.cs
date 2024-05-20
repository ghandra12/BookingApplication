using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers
{
    [Authorize]
    public class BarbershopController : Controller
    {
        private readonly BarbershopService barbershopService;
        private readonly BarbershopReservationService barbershopReservationService;
        public BarbershopController(BarbershopService barbershopService, BarbershopReservationService barbershopReservationService)
        {
            this.barbershopService = barbershopService;
            this.barbershopReservationService = barbershopReservationService;
        }

        public IActionResult Index()
        {
            var barbershops = barbershopService.GetAllBarbershops();
            return View(barbershops);
        }

        [HttpGet]
        [Route("/Barbershop/BarbershopReservation/{id}")]
        public IActionResult BarbershopReservation(Guid id)
        {
            var barbershop = this.barbershopService.GetBarbershopById(id);
            ViewData["barbershop"] = barbershop;
            return View();
        }
        [HttpPost]
        [Route("/Barbershop/BarbershopReservation/{id}")]
        public IActionResult BarbershopReservation(Guid id, [FromForm] BarbershopReservation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var barbershop = this.barbershopService.GetBarbershopById(id);
            this.barbershopReservationService.AddReservation(new BarbershopReservation()
            {
                Id = Guid.NewGuid(),
                Barbershop = barbershop,
                Date = model.Date,
                StartHour = model.StartHour
            });
            return Redirect(Url.Action("Index", "Barbershop"));
        }
        [HttpGet]
        public IActionResult AddBarbershop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBarbershop([FromForm] Barbershop model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.barbershopService.AddBarbershop(model);
            return Redirect(Url.Action("Index", "Barbershop"));
        }
        [HttpGet]
        public IActionResult DeleteBarbershop()
        {
            var barbershopsIds = barbershopService.GetAllBarbershopIds();
            ViewData["BarbershopIds"] = barbershopsIds;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteBarbershop([FromForm] Barbershop model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.barbershopService.DeleteBarbershop(model.Id);
            return Redirect(Url.Action("Index", "Barbershop"));
        }
        [HttpGet]
        public IActionResult UpdateBarbershop()
        {
            var barbershopsIds = barbershopService.GetAllBarbershopIds();
            ViewData["BarbershopIds"] = barbershopsIds;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateBarbershop([FromForm] Barbershop model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.barbershopService.UpdateBarbershop(model);
            return Redirect(Url.Action("Index", "Barbershop"));
        }
    }

}
