using skillhub.CommonLayer.Model;

namespace skillhub.ServiceLayer
{
    public interface UserInterfaceSL
    {
        public Task<UserRegisterResponse> AddUserRegister(UserRegisterRequest request);
    }
}
