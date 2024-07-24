using System.ComponentModel.DataAnnotations;

namespace ShagunGraminHealth.Models
{
    public class RegistrationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        [Required]
        [StringLength(255)]
        public string? Mobile { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string? Password { get; set; }

        public int? ReferenceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Passcode { get; set; }

        public string ? Role {  get; set; }



    }
}
    
    


