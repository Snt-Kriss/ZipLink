using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipLink.Data.Models;

namespace ZipLink.Data.Services
{
    public interface IUserService
    {
        Task<List<AppUser>> GetUsersAsync();
        //Task<AppUser> GetByIdAsync(string id);
        //Task<AppUser> UpdateAsync(string id, AppUser user);
        //Task DeleteAsync(string id);

        //Task<AppUser> AddAsync(AppUser user);
    }
}
