using System.ComponentModel.DataAnnotations;

namespace ShagunGraminHealth.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Name is necessary")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "password is necessary")]
        public string? Password { get; set; }
    }
}
