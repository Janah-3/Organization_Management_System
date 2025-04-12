using Demo.DataAccess.Models.IdentityModel;
using Demo.Presntation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presntation.Controllers
{
    public class AccountController (UserManager<ApplicationUser> _userManager): Controller
    {
        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            var user = new ApplicationUser()
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };
            var result = _userManager.CreateAsync(user , viewModel.Password).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(viewModel);
            }
        }
    }
}
