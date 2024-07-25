using System;
using System.Collections.Generic;

namespace ShagunGraminHealth.Models
{
    public partial class MembershipPlan
    {
        public int Id { get; set; }
        public string PlanNumber { get; set; } = null!;
        public string PlanName { get; set; } = null!;
        public decimal PlanFee { get; set; }
        public string? ApplicationId { get; set; }
    }
}