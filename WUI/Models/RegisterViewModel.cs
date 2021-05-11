using System.ComponentModel.DataAnnotations;

namespace WUI.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
 
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Passwords not equal.")]
        [DataType(DataType.Password)]
        [Display(Name = "Re-type password")]
        public string ConfirmPassword { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        [MinLength(4)]
        [Display(Name = "Your name")]
        public string Name { get; set; }
        
        
        [DataType(DataType.Date)]
        [Required]
        [MinLength(4)]
        [Display(Name = "Birthday")]
        public string Birtday { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Your address")]
        public string Address { get; set; }
    }
}