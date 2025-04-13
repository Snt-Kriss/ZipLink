using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZipLink.Client.Data.ViewModel;
using ZipLink.Data;
using ZipLink.Data.Models;

namespace ZipLink.Client.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
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

            var newUrl = new Url()
            {
                OriginalLink = postUrlVM.Url,
                ShortLink = GenerateURL(6),
                NumberOfClicks = 0,
                UserId= null,
                DateCreated = DateTime.Now
            };

            _context.Urls.Add(newUrl);
            _context.SaveChanges();

            TempData["Message"] = $"URL shortened successfully to {newUrl.ShortLink}";
            
            return RedirectToAction("Index");
        }

        private string GenerateURL(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s=> s[random.Next(s.Length)]).ToArray());
        }
    }

    
}
