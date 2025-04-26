using skillhub.CommonLayer.Model;

namespace skillhub.RepositeryLayer
{
    public interface UserInterfaceRL
    {
        public Task<UserRegisterResponse> RegisterUser(UserRegisterRequest request);
    }
}
