using skillhub.CommonLayer.Model.Users;

namespace skillhub.Interfaces
{
    public interface UserInterfaceRL
    {
        public Task<UserRegisterResponse> RegisterUser(User request);

        public Task<string> AuthenticateUser(string email, string password);

        public Task<bool> CheckEmailExists(string email);

        public Task<bool> CheckUserNameExists(string userName);
    }
}
