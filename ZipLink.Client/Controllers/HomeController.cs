using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZipLink.Client.Data.ViewModel;

namespace ZipLink.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var newUrl = new PostUrlVM();
            return View(newUrl);
        }


        //handle the form request
        public IActionResult ShortenURL(PostUrlVM postUrlVM)
        {
            //Validate VM properties
            if (!ModelState.IsValid)
            {
                return View("Index", postUrlVM);
            }
            
            return RedirectToAction("Index");
        }

        
    }
}
