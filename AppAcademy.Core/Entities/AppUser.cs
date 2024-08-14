using Microsoft.AspNetCore.Identity;

namespace AppAcademy.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
