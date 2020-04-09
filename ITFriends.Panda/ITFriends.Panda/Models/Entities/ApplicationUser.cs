using System;
using Microsoft.AspNetCore.Identity;

namespace ITFriends.Panda.Models
{
    public class ApplicationUser: IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public ApplicationUser()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
