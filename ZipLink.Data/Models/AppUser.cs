using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ZipLink.Data.Models
{
    public class AppUser: IdentityUser
    {
        //Good practice to avoid null reference when trying to add url collection to a user for the first time.
        public AppUser()
        {
            Urls = new List<Url>();
        }

        //Navigational property- Used to get child/parent data of a model
        public List<Url> Urls { get; set; }


        public string FullName { get; set; }


        
        


    }
}
