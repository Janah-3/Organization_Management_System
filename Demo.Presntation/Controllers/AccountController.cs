using Microsoft.AspNetCore.Mvc;

namespace Demo.Presntation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register() 
        {
            return View();
        }
    }
}
