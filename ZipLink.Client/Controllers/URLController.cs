using Microsoft.AspNetCore.Mvc;
using ZipLink.Client.Data.ViewModel;
using ZipLink.Data.Services;

namespace ZipLink.Client.Controllers
{
    public class URLController : Controller
    {
        private IUrlsService _urlServce;
        public URLController(IUrlsService urlsService)
        {
            _urlServce = urlsService;
        }
        public async Task<IActionResult> Index()
        {
            var entities = await _urlServce.GetUrlsAsync();

            var allUrlsFromDb =entities
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

        public async  Task<IActionResult> Remove(int id)
        {
            await _urlServce.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
