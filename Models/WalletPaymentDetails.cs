namespace ShagunGraminHealth.Models
{
    public class WalletPaymentDetails
    {
        public int Id { get; set; }
        public int WalletId { get; set; }

        public string UserRefId { get; set; } 
        public decimal Amount { get; set; }
        public string PaymentId { get; set; }
        public string OrderId { get; set; }

        public DateTime TransactionDate { get; set; }
        public Wallet Wallet { get; set; }
    }
}
