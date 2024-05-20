using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApplication.Controllers
{
    [Authorize]
    public class CinemaController : Controller
    {
        private readonly CinemaService CinemaService;
        private readonly CinemaReservationService CinemaReservationService;
        public CinemaController(CinemaService CinemaService, CinemaReservationService CinemaReservationService)
        {
            this.CinemaService = CinemaService;
            this.CinemaReservationService = CinemaReservationService;
        }

        public IActionResult Index()
        {
            var Cinemas = CinemaService.GetAllCinemas();
            return View(Cinemas);
        }

        [HttpGet]
        [Route("/Cinema/CinemaReservation/{id}")]
        public IActionResult CinemaReservation(int id)
        {
            var Cinema = this.CinemaService.GetCinemaById(id);
            ViewData["Cinema"] = Cinema;
            return View();
        }
        [HttpPost]
        [Route("/Cinema/CinemaReservation/{id}")]
        public IActionResult CinemaReservation(int id, [FromForm] CinemaReservation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var usr = this.User;
            Guid usId = Guid.Parse(usr.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value);

            var Cinema = this.CinemaService.GetCinemaById(id);
            this.CinemaReservationService.AddReservation(new CinemaReservation()
            {
                Id = Guid.NewGuid(),
                Cinema = Cinema,
                Date = model.Date,
                StartHour = model.StartHour,
                UserId = usId
            });
            return Redirect(Url.Action("Index", "Cinema"));
        }
        [HttpGet]
        public IActionResult AddCinema()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCinema([FromForm] Cinema model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.CinemaService.AddCinema(model);
            return Redirect(Url.Action("Index", "Cinema"));
        }
        [HttpGet]
        public IActionResult DeleteCinema()
        {
            var CinemasIds = CinemaService.GetAllCinemaIds();
            ViewData["CinemaIds"] = CinemasIds;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCinema([FromForm] Cinema model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.CinemaService.DeleteCinema(model.Id);
            return Redirect(Url.Action("Index", "Cinema"));
        }
        [HttpGet]
        public IActionResult UpdateCinema()
        {
            var CinemasIds = CinemaService.GetAllCinemaIds();
            ViewData["CinemaIds"] = CinemasIds;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCinema([FromForm] Cinema model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.CinemaService.UpdateCinema(model);
            return Redirect(Url.Action("Index", "Cinema"));
        }
    }

}
