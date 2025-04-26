using Azure;
using skillhub.CommonLayer.Model;
using skillhub.RepositeryLayer;

namespace skillhub.ServiceLayer
{
    public class UserSL : UserInterfaceSL
    {
        public readonly UserInterfaceRL userInterface;
        public UserSL(UserInterfaceRL userInterface)
        {
            this.userInterface = userInterface;
        }

        public async Task<UserRegisterResponse> AddUserRegister(UserRegisterRequest request)
        {
            UserRegisterResponse response = new UserRegisterResponse();
            try
            {
                return await userInterface.RegisterUser(request);
            }
            catch (Exception ex) {
                response.isSuccess = false;
                response.message = ex.Message;
            }
            return response;
        }

    }
}
