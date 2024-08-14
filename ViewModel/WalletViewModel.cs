namespace ShagunGraminHealth.ViewModel
{
    public class WalletViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ReferenceId { get; set; }
        public string? TransactionCount { get; set; }
        public string? TotalBalance { get; set; }
        public string? Status { get; set; }
        public string PaymentId { get; set; } 
        public string OrderId { get; set; }
        public string MemberOrderId { get; set; }
        public string MemberPaymentId { get; set; }
    }
}
