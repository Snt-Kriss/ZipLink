using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZipLink.Client.Data.ViewModel;
using ZipLink.Data;

namespace ZipLink.Client.Controllers
{
    public class URLController : Controller
    {
        private AppDbContext _context;
        public URLController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            //Fake Db data
            var allUrls = new List<GetUrlVM>()
            {
                new GetUrlVM()
                {
                    Id=2,
                    OriginalLink= "https://link2.com",
                    ShortLink= "https://ziplink.1234",
                    NumberOfClicks=2,
                    UserId=2
                },
                new GetUrlVM()
                {
                    Id=3,
                    OriginalLink= "https://link3.com",
                    ShortLink= "https://ziplink.12345",
                    NumberOfClicks=2,
                    UserId=3
                }
            };

            //SELECT Id, OriginalLink, etc FROM URLS
            var allUrlsFromDb = _context.Urls.Include(n => n.User).Select(url => new GetUrlVM()
            {
                Id = url.Id,
                OriginalLink = url.OriginalLink,
                ShortLink = url.ShortLink,
                NumberOfClicks = url.NumberOfClicks,
                UserId = url.UserId,

                User = url.User != null ? new GetUserVM()
                {
                    Id = url.User.Id,
                    FullName = url.User.FullName
                } : null
            }).ToList();

            return View(allUrlsFromDb);
        }

        public IActionResult Remove(int id)
        {
            var url = _context.Urls.FirstOrDefault(n => n.Id == id);

            if (url == null)
            {
                TempData["Error"] = "URL not found.";
                return RedirectToAction("Index");
            }

            _context.Urls.Remove(url);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
