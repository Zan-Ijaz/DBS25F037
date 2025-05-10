namespace skillhub.CommonLayer.Model.Users
{
    public class WalletRequest
    {
        public float coinbalance { get; private set; }
        public DateTime lastUpdated { get; private set; }
        public string status { get; private set; }
        public int userID { get; private set; }


    }
}
