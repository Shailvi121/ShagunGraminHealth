using System.ComponentModel.DataAnnotations;

namespace ShagunGraminHealth.Areas.Admin.Models
{
    public class MembershipPlan
    {
        [Key]
        public int? Id { get; set; }
        public string? PlanNumber { get; set; }
        public string? PlanName { get; set; }
        public decimal? PlanFee { get; set; }
    }

}
