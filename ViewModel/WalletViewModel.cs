namespace ShagunGraminHealth.ViewModel
{
    public class WalletViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ReferenceId { get; set; }
        public int TransactionCount { get; set; }
        public decimal TotalBalance { get; set; }
        public string Status { get; set; }
    }
}
