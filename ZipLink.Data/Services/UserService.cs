using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZipLink.Data.Models;

namespace ZipLink.Data.Services
{
    public class UserService: IUserService
    {
        private AppDbContext _context;
        public UserService(AppDbContext context)

        {
            _context = context;
        }

        

        //public async Task<AppUser> GetByIdAsync(string id)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
        //    return user;
        //}

        public async Task<List<AppUser>> GetUsersAsync()
        {
            var users =await _context.Users.Include(n => n.Urls).ToListAsync();
            return users;
        }

        //public async Task<AppUser> AddAsync(AppUser user)
        //{
        //    await _context.Users.AddAsync(user);
        //    await _context.SaveChangesAsync();
        //    return user;
        //}

        //public async Task<AppUser> UpdateAsync(string id, AppUser user)
        //{
        //    var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        //    if (userDb != null)
        //    {
        //        userDb.Email = user.Email;
        //        userDb.FullName = user.FullName;

        //        //_context.Update(userDb);
        //       await  _context.SaveChangesAsync();

        //    }
        //    return userDb;
        //}

        //public async Task DeleteAsync(string id)
        //{
        //    var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        //    if (userDb != null)
        //    {
        //        _context.Users.Remove(userDb);
        //        await _context.SaveChangesAsync();
        //    }
        //}

       
    }
}
