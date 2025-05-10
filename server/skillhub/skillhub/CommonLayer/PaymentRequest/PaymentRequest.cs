namespace skillhub.CommonLayer.PaymentRequest
{
    public class PaymentRequest
    {
        public int RequestID { get; set; }
        public int User { get; set; }
        public float CoinAmount { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public DateTime ApprovedDate { get; set; }
    }
}
