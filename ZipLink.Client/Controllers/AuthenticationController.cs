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

        public IActionResult Login()
        {
            var initial = new LoginVM();
            return View(initial);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login(LoginVM loginVM)
        {
            return View();
        }
    }
}
