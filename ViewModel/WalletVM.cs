namespace ShagunGraminHealth.ViewModel
{
    public class WalletVM
    {
        public int Id { get; set; }
        public string? ReferenceId { get; set; }
        public int UserId { get; set; }
        public string? OrderId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
