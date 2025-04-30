using skillhub.CommonLayer.Model.Users;

namespace skillhub.Interfaces
{
    public interface UserInterfaceSL
    {
        public Task<UserRegisterResponse> AddUserRegister(UserRegisterRequest request);
        public Task<string> AuthenticateUser(string email, string password);
    }
}
