namespace skillhub.CommonLayer.Model.Users
{
    public class RegisterRequest
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public int roleID { get; set; }
    }
}
