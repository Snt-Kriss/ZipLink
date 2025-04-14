using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipLink.Data.Models;

namespace ZipLink.Data.Services
{
    public interface IUrlsService
    {
        List<Url> GetUrls();
        Url GetById(int id);
        Url Update(int id, Url url);
        void Delete(int id);
        Url Add(Url url);
    }
}
