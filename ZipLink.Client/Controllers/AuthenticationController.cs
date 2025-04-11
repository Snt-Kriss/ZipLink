using Microsoft.AspNetCore.Mvc;
using ZipLink.Client.Data.ViewModel;

namespace ZipLink.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }

        //Render
        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        //Handle
        public IActionResult LoginSubmitted(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginVM);
            }
            return RedirectToAction("Index", "Home");
        }

        //Render
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        public IActionResult RegisterUser(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", registerVM);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
