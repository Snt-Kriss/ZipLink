using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipLink.Data.Models
{
    public class User
    {
       

        public int Id { get; set; }
        public string Email { get; set; }

        //Navigational property- Used to get child/parent data of a model
        public List<Url> Urls { get; set; }


        public string FullName { get; set; }

        public User()
        {
            Urls = new List<Url>();
        }


    }
}
