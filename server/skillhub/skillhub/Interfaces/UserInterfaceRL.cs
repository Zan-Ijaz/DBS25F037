using skillhub.CommonLayer.Model.Users;

namespace skillhub.Interfaces
{
    public interface UserInterfaceRL
    {
        public Task<UserRegisterResponse> RegisterUser(UserRegisterRequest request);

        public Task<string> AuthenticateUser(string email, string password);
    }
}
