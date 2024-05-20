using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingApplication.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        private readonly RestaurantService RestaurantService;
        private readonly RestaurantReservationService RestaurantReservationService;
        public RestaurantController(RestaurantService RestaurantService, RestaurantReservationService RestaurantReservationService)
        {
            this.RestaurantService = RestaurantService;
            this.RestaurantReservationService = RestaurantReservationService;
        }

        public IActionResult Index()
        {
            var Restaurants = RestaurantService.GetAllRestaurants();
            return View(Restaurants);
        }

        [HttpGet]
        [Route("/Restaurant/RestaurantReservation/{id}")]
        public IActionResult RestaurantReservation(int id)
        {
            var Restaurant = this.RestaurantService.GetRestaurantById(id);
            ViewData["Restaurant"] = Restaurant;
            return View();
        }
        [HttpPost]
        [Route("/Restaurant/RestaurantReservation/{id}")]
        public IActionResult RestaurantReservation(int id, [FromForm] RestaurantReservation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var usr = this.User;
            Guid usId = Guid.Parse(usr.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value);

            var Restaurant = this.RestaurantService.GetRestaurantById(id);
            this.RestaurantReservationService.AddReservation(new RestaurantReservation()
            {
                Id = Guid.NewGuid(),
                Restaurant = Restaurant,
                Date = model.Date,
                StartHour = model.StartHour,
                UserId = usId
            });
            return Redirect(Url.Action("Index", "Restaurant"));
        }
        [HttpGet]
        public IActionResult AddRestaurant()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRestaurant([FromForm] Restaurant model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.RestaurantService.AddRestaurant(model);
            return Redirect(Url.Action("Index", "Restaurant"));
        }
        [HttpGet]
        public IActionResult DeleteRestaurant()
        {
            var RestaurantsIds = RestaurantService.GetAllRestaurantIds();
            ViewData["RestaurantIds"] = RestaurantsIds;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteRestaurant([FromForm] Restaurant model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.RestaurantService.DeleteRestaurant(model.Id);
            return Redirect(Url.Action("Index", "Restaurant"));
        }
        [HttpGet]
        public IActionResult UpdateRestaurant()
        {
            var RestaurantsIds = RestaurantService.GetAllRestaurantIds();
            ViewData["RestaurantIds"] = RestaurantsIds;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateRestaurant([FromForm] Restaurant model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this.RestaurantService.UpdateRestaurant(model);
            return Redirect(Url.Action("Index", "Restaurant"));
        }
    }

}
