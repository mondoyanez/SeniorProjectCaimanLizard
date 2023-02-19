using Microsoft.AspNetCore.Mvc;

namespace WatchParty.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }

        
    }
}
