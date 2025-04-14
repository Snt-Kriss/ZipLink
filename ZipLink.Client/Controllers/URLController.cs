using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZipLink.Client.Data.ViewModel;
using ZipLink.Data;
using ZipLink.Data.Services;

namespace ZipLink.Client.Controllers
{
    public class URLController : Controller
    {
        //private AppDbContext _context;
        private IUrlsService _urlServce;
        public URLController(IUrlsService urlsService)
        {
            _urlServce = urlsService;
        }
        public IActionResult Index()
        {

            //SELECT Id, OriginalLink, etc FROM URLS
            var allUrlsFromDb = _urlServce.GetUrls()
                .Select(url => new GetUrlVM()
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
            _urlServce.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
