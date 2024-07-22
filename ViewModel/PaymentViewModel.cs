namespace ShagunGraminHealth.ViewModel
{
    public class PaymentViewModel
    {
        public string razorpay_payment_id { get; set; }
        public string razorpay_order_id { get; set; }
        public string razorpay_signature { get; set; }
        public int UserId { get; set; }
    }
}
