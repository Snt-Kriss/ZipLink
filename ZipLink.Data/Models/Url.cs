using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipLink.Data.Models
{
    public class Url
    {
        //model property
        public int Id { get; set; }
        public string OriginalLink { get; set; }
        public string ShortLink { get; set; }
        public int NumberOfClicks { get; set; }
        public string? UserId { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AppUser User { get; set; }
    }
}
