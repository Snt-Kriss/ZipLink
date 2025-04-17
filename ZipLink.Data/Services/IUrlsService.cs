﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipLink.Data.Models;

namespace ZipLink.Data.Services
{
    public interface IUrlsService
    {
        Task<List<Url>> GetUrlsAsync();
        Task<Url> GetByIdAsync(int id);
        Task<Url> UpdateAsync(int id, Url url);
        Task DeleteAsync(int id);
        Task<Url> AddAsync(Url url);
    }
}
