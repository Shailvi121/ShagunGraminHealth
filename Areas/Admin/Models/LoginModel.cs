using System.ComponentModel.DataAnnotations;

namespace ShagunGraminHealth.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Name is necessary")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "password is necessary")]
        public string? Password { get; set; }
    }
}
