using Microsoft.AspNetCore.Identity;

namespace BlazorCCSE.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string forename { get; set; }
        public string surname { get; set; }
        public string passportNumber { get; set; }
        public string contactNumber { get; set; }
    }
}
