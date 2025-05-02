using skillhub.CommonLayer.Model.Users;

namespace skillhub.Interfaces
{
    public interface UserInterfaceSL
    {
        public Task<UserRegisterResponse> AddUserRegister(User request);
        public Task<string> AuthenticateUser(string email, string password);

        public Task<bool> CheckEmailExists(string email);

        public Task<bool> CheckUserNameExists(string userName);

    }
}
