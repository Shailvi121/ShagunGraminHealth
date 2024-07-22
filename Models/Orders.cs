namespace ShagunGraminHealth.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string? OrderId { get; set; }
        public decimal PaymentAmount {  get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public bool IsActive {  get; set; }
        public string? PaymentStatus { get; set; }
    }
}
