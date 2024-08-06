﻿using ShagunGraminHealth.Models;

namespace ShagunGraminHealth.ViewModel
{
    public class WalletPaymentDetailsVM
    {
        public int Id { get; set; }
        public int WalletId { get; set; }

        public string UserRefId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Wallet Wallet { get; set; }
    }
}
