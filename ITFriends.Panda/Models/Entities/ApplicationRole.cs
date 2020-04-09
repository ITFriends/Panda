using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ITFriends.Panda.Models
{
    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName, string roleDescription) : base(roleName)
        {
            this.Description = roleDescription;
            this.CreatedDate = DateTime.Today;
        }

        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
