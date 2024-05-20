using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApplication.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly HotelService HotelService;
        private readonly HotelReservationService HotelReservationService;
        public HotelController(HotelService HotelService, HotelReservationService HotelReservationService)
        {
            this.HotelService = HotelService;
            this.HotelReservationService = HotelReservationService;
        }

        public IActionResult Index()
        {
            var Hotels = HotelService.GetAllHotels();
            return View(Hotels);
        }

        [HttpGet]
        [Route("/Hotel/HotelReservation/{id}")]
        public IActionResult HotelReservation(int id)
        {
            var Hotel = this.HotelService.GetHotelById(id);
            ViewData["Hotel"] = Hotel;
            return View();
        }
        [HttpPost]
        [Route("/Hotel/HotelReservation/{id}")]
        public IActionResult HotelReservation(int id, [FromForm] HotelReservation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var usr = this.User;
            Guid usId = Guid.Parse(usr.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value);

            var Hotel = this.HotelService.GetHotelById(id);
            this.HotelReservationService.AddReservation(new HotelReservation()
            {
                Id = Guid.NewGuid(),
                Hotel = Hotel,
                Date = model.Date,
                StartHour = model.StartHour,
                UserId = usId,
            });
            return Redirect(Url.Action("Index", "Hotel"));
        }
        [HttpGet]
        public IActionResult AddHotel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHotel([FromForm] Hotel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.HotelService.AddHotel(model);
            return Redirect(Url.Action("Index", "Hotel"));
        }
        [HttpGet]
        public IActionResult DeleteHotel()
        {
            var HotelsIds = HotelService.GetAllHotelIds();
            ViewData["HotelIds"] = HotelsIds;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteHotel([FromForm] Hotel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.HotelService.DeleteHotel(model.Id);
            return Redirect(Url.Action("Index", "Hotel"));
        }
        [HttpGet]
        public IActionResult UpdateHotel()
        {
            var HotelsIds = HotelService.GetAllHotelIds();
            ViewData["HotelIds"] = HotelsIds;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateHotel([FromForm] Hotel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.HotelService.UpdateHotel(model);
            return Redirect(Url.Action("Index", "Hotel"));
        }
    }

}
