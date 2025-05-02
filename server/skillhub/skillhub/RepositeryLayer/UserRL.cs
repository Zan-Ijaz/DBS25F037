using System.IdentityModel.Tokens.Jwt;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using skillhub.Common_Utilities;
using skillhub.Common_Utility;
using skillhub.CommonLayer.Model.Users;
using skillhub.Interfaces;

namespace skillhub.RepositeryLayer
{
    public class UserRL : UserInterfaceRL
    {
        public readonly IConfiguration configuration;
        public readonly MySqlConnection mySqlConnection;

        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
            mySqlConnection = new MySqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }

        public async Task<UserRegisterResponse> RegisterUser(User request)
        {
            UserRegisterResponse response = new UserRegisterResponse();

            try
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await mySqlConnection.OpenAsync();
                }

                string commandText = SqlQueries.RegisterUser;


                if (string.IsNullOrWhiteSpace(commandText))
                {
                    throw new InvalidOperationException("The SQL query for RegisterUser is not defined or is empty.");
                }

                string userExists = SqlQueries.emailExists;
                using (MySqlCommand sqlCommand = new MySqlCommand(userExists, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@email", request.email);

                    int userCount = Convert.ToInt32(await sqlCommand.ExecuteScalarAsync());
                    if (userCount > 0)
                    {
                        response.isSuccess = false;
                        response.message = "User already exists.";
                        return response;
                    }
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@email", request.email);

                    string hasedPassword = PasswordHasher.HashPassword(request.passwordHash);
                    sqlCommand.Parameters.AddWithValue("@passwordHash", hasedPassword);

                    sqlCommand.Parameters.AddWithValue("@userName", request.userName);
                    sqlCommand.Parameters.AddWithValue("@roleID", request.roleID);
                   

                    int status = await sqlCommand.ExecuteNonQueryAsync();

                    if (status <= 0)
                    {
                        response.isSuccess = false;
                        response.message = "Failed to register user.";
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.message = ex.Message;
                Console.WriteLine(ex);
            }
            finally
            {
                await mySqlConnection.CloseAsync();
                await mySqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<string> AuthenticateUser(string email, string password)
        {
            try
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await mySqlConnection.OpenAsync();
                }

                string commandText = SqlQueries.AuthenticateUser;

                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@password", password);

                    using var reader = await sqlCommand.ExecuteReaderAsync();


                    if (await reader.ReadAsync())
                    {
                        var storedHash = reader.GetString("PasswordHash");
                        var userID = reader.GetInt32("userID");
                        var userName = reader.GetString("userName");
                        var roleID = reader.GetInt32("roleID");

                        string role;
                        if (roleID == 1)
                        {
                            role = "User";
                        }
                        else if (roleID == 2)
                        {
                            role = "Freelancer";
                        }
                        else if (roleID == 3)
                        {
                            role = "Client";
                        }
                        else if (roleID == 4)
                        {
                            role = "Admin";
                        }
                        else
                        {
                            role = "Unknown";
                        }
                        {

                        }

                        if (PasswordHasher.VerifyPassword(password, storedHash))
                        {
                            return JwtHelper.GenerateToken(userID, email, userName, role, configuration);
                        }
                        else
                        {
                            return "Invalid credentials";
                        }
                    }
                    else
                    {
                        return "Invalid credentials";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Error occurred during authentication";
            }
            finally
            {
                await mySqlConnection.CloseAsync();
                await mySqlConnection.DisposeAsync();
            }
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            try
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await mySqlConnection.OpenAsync();
                }
                string commandText = SqlQueries.emailExists;
                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    int userCount = Convert.ToInt32(await sqlCommand.ExecuteScalarAsync());
                    return userCount > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> CheckUserNameExists(string userName)
        {
            try
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await mySqlConnection.OpenAsync();
                }
                string commandText = SqlQueries.userNameExists;
                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@userName", userName);
                    int userCount = Convert.ToInt32(await sqlCommand.ExecuteScalarAsync());
                    return userCount > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }


        }
    }
}

