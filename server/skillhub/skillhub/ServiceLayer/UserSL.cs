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

        public async Task<UserRegisterResponse> AddUserRegister(RegisterRequest request)
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
            if (string.IsNullOrWhiteSpace(request.passwordHash))
            {
                response.isSuccess = false;
                response.message = "Password can't be empty";
            }
            if(request.passwordHash.Length < 8)
            {
                response.isSuccess = false;
                response.message = "Password must be at least 8 characters long";
                return response;
            }
            else if (!Regex.IsMatch(request.passwordHash, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"))
            {
                response.isSuccess = false;     
                response.message = "Password must contain at least one uppercase letter, one lowercase letter, and one number";
                return response;
            }

            User newUser = new User(request.userName, request.email, request.passwordHash, request.roleID);

            try
            {
                return await userInterface.RegisterUser(newUser);
            }
            catch (Exception ex) {
                response.isSuccess = false;
                response.message = ex.Message;
            }
            return response;
        }
        public async Task<string> AuthenticateUser(UserLogin userLogin)
        {
            User authUser = new User(userLogin.email, userLogin.password);
            return await userInterface.AuthenticateUser(authUser);
        }

        public Task<bool> CheckEmailExists(string email)
        {
            return userInterface.CheckEmailExists(email);
        }
        public Task<bool> CheckUserNameExists(string userName)
        {
            return userInterface.CheckUserNameExists(userName);
        }

        public async Task<bool> AddPersonalInformation(PersonalInformation personalInformation)
        {
            if (string.IsNullOrWhiteSpace(personalInformation.firstName))
                return false;

            if (string.IsNullOrWhiteSpace(personalInformation.lastName))
                return false;

            if (string.IsNullOrWhiteSpace(personalInformation.phone) || personalInformation.phone.Length != 11)
                return false;

            if (string.IsNullOrWhiteSpace(personalInformation.country))
                return false;

            if (string.IsNullOrWhiteSpace(personalInformation.profilePicture))
                return false;

            if (string.IsNullOrWhiteSpace(personalInformation.bio))
                return false;

            if (string.IsNullOrWhiteSpace(personalInformation.language))
                return false;

            // Create User object with constructor (ensure you’ve defined it)
            User userInformation = new User(
                personalInformation.userID,
                personalInformation.firstName,
                personalInformation.lastName,
                personalInformation.phone,
                personalInformation.country,
                personalInformation.profilePicture,
                personalInformation.bio,
                personalInformation.language
            );

            // Call to service/repository
            return await userInterface.AddPersonalInformation(userInformation);
        }




    }
}
