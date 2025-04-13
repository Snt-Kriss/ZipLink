using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZipLink.Client.Data.ViewModel;
using ZipLink.Data;

namespace ZipLink.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        private AppDbContext _context;

        public AuthenticationController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Users()
        {
            var users = _context.Users.Include(n=> n.Urls).ToList();
            return View(users);
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
