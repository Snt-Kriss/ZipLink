using Microsoft.AspNetCore.Mvc;
using ZipLink.Client.Data.Models;
using ZipLink.Client.Data.ViewModel;

namespace ZipLink.Client.Controllers
{
    public class URLController : Controller
    {
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
            return View(allUrls);
        }

        
    }
}
