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
        List<User> GetUsers();
        User GetById(int id);
        User Update(int id, User user);
        void Delete(int id);

        User Add(User user);
    }
}
