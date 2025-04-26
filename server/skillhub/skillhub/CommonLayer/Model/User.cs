using Microsoft.Extensions.Primitives;

namespace skillhub.CommonLayer.Model
{
    public class UserRegisterRequest
    {
        public string userName { get; set; }

        public string email { get; set; }
        
        public string password { get; set; }
    }

    public class UserRegisterResponse
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
}
