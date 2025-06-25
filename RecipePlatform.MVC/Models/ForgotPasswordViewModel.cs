using System.ComponentModel.DataAnnotations;

namespace RecipePlatform.PL.MVC.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
