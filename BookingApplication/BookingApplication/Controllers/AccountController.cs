using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace BookingApplication.Controllers
{
    public class AccountController : Controller
    {
       
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Recovery()
        {
            return View();
        }
    }
}
