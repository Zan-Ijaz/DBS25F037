using skillhub.CommonLayer.Model.Users;

namespace skillhub.Interfaces
{
    public interface UserInterfaceSL
    {
        public Task<UserRegisterResponse> AddUserRegister(RegisterRequest request);
        public Task<string> AuthenticateUser(UserLogin userLogin);

        public Task<bool> CheckEmailExists(string email);

        public Task<bool> CheckUserNameExists(string userName);

        

    }
}
