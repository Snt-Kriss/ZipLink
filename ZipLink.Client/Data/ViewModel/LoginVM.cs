using System.ComponentModel.DataAnnotations;
using System.Net;
using ZipLink.Client.Helpers.Validators;

namespace ZipLink.Client.Data.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email Address is required")]
        //[EmailAddress(ErrorMessage ="Invalid email address")]
        //[RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Invalid email address")]
        [CustomEmailValidator(ErrorMessage ="Email address is not valid")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [MinLength(8, ErrorMessage ="Password must be at least 8 characters")]
        public string Password { get; set; }
    }
}
