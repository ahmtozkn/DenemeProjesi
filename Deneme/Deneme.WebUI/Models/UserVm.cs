using System.ComponentModel.DataAnnotations;

namespace Deneme.WebUI.Models
{
    public class UserVm
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string userName { get; set; }   
        public bool RememberMe { get; set; }
    }
}
