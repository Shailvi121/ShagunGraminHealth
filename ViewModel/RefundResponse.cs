namespace ShagunGraminHealth.ViewModel
{
    public class RefundResponse
    {
        public string Id { get; set; }
        public string Entity { get; set; }
        public int Amount { get; set; }
        public int AmountRefunded { get; set; }
        public string Currency { get; set; }
        public string PaymentId { get; set; }
        public string OrderId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
