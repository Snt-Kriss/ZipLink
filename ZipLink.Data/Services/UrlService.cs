using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZipLink.Data.Models;

namespace ZipLink.Data.Services
{
    public class UrlService: IUrlsService
    {
        private AppDbContext _context;
        public UrlService(AppDbContext context)

        {
            _context = context;
        }

        

        public async Task<Url> GetByIdAsync(int id)
        {
            var url =await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);
            return url;
        }

        public async Task<List<Url>> GetUrlsAsync()
        {
            var allUrls = await _context.Urls.Include(n => n.User).ToListAsync();
            return allUrls;
        }

        public async Task<Url> AddAsync(Url url)
        {
            _context.Urls.Add(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task<Url> UpdateAsync(int id, Url url)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(u => u.Id == id);
            if (urlDb != null)
            {
                urlDb.OriginalLink = url.OriginalLink;
                urlDb.ShortLink = url.ShortLink;
                urlDb.DateUpdated = DateTime.Now;

                await _context.SaveChangesAsync();
            }

            return urlDb;
        }

        public async Task DeleteAsync(int id)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(u => u.Id == id);
            if (urlDb != null)
            {
                _context.Remove(urlDb);
                await _context.SaveChangesAsync();
            }
        }

      
    }
}
