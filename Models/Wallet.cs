using System;
using System.Collections.Generic;

namespace ShagunGraminHealth.Models
{
    public partial class Wallet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ReferenceId { get; set; } = null!;
        public string? TotalBalance { get; set; }
        public string? Status { get; set; }
        public string? TranscationCount { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<WalletPaymentDetails> WalletPaymentDetails { get; set; } = new HashSet<WalletPaymentDetails>();
    }
}
