using System.Text.RegularExpressions;
using Azure;
using skillhub.CommonLayer.Model.Users;
using skillhub.Interfaces;

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
           
            if (string.IsNullOrWhiteSpace(request.email))
            {
                response.isSuccess = false;
                response.message = "Email can't be empty";
                return response;
            }
            else if (!Regex.IsMatch(request.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                response.isSuccess = false;
                response.message = "Invalid email format";
                return response;
            }
            if (string.IsNullOrWhiteSpace(request.password))
            {
                response.isSuccess = false;
                response.message = "Password can't be empty";
            }
            if(request.password.Length < 8)
            {
                response.isSuccess = false;
                response.message = "Password must be at least 8 characters long";
                return response;
            }
            else if (!Regex.IsMatch(request.password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"))
            {
                response.isSuccess = false;     
                response.message = "Password must contain at least one uppercase letter, one lowercase letter, and one number";
                return response;
            }

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
        public async Task<string> AuthenticateUser(string email, string password)
        {
            return await userInterface.AuthenticateUser(email, password);
        }

    }
}
