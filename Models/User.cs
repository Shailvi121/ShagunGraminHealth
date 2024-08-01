using System;
using System.Collections.Generic;

namespace ShagunGraminHealth.Models
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public string? ReferenceId { get; set; } 
        public string? Address { get; set; }
        public string? Passcode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; } = null!;
        public string? Role { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
