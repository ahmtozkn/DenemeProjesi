using System.ComponentModel.DataAnnotations;

namespace Deneme.WebUI.Models
{
    public class RegisterVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parola ile uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

    }
}
