using System.ComponentModel.DataAnnotations;

namespace ITFriends.Panda.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Minimum length is 6 symbols", MinimumLength = 6)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password minimal length is 6 symbols", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Paswords doesn't match")]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
