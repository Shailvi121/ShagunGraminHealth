namespace ShagunGraminHealth.Models
{
    public class PaymentOrder
    {

       
            public int Id { get; set; }
            public string? OrderId { get; set; }
            public string? PaymentStatus { get; set; }
            public string? RazorPaymentId { get; set; }
            public int? UserId { get; set; }
       

    }
}
