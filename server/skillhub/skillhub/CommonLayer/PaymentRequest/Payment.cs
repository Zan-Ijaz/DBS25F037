namespace skillhub.CommonLayer.PaymentRequest
{
    public class Payment
    {
        public int RequestID { get; private set; }
        public User User { get; private set; }
        public float CoinAmount { get; private set; }
        public DateTime RequestDate { get; private set; }
        public string Status { get; private set; }
        public DateTime ApprovedDate { get; private set; }
        public Payment(int requestID, User user, float coinAmount, DateTime requestDate, string status, DateTime approvedDate)
        {
            RequestID = requestID;
            User = user;
            CoinAmount = coinAmount;
            RequestDate = requestDate;
            Status = status;
            ApprovedDate = approvedDate;
        }
        public Payment( User user, float coinAmount, DateTime approvedDate)
        {
            if (coinAmount <= 0)
            {
                throw new ArgumentException("Requested coins must be grater than 0.");
            }
            User = user;
            CoinAmount = coinAmount;
            Status = "Pending";
            ApprovedDate = approvedDate;
        }
    }
}
