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

        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest request)
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

                string userExists = SqlQueries.userExist;
                using(MySqlCommand sqlCommand = new MySqlCommand(userExists, mySqlConnection))
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

                    string hasedPassword = PasswordHasher.HashPassword(request.password);
                    sqlCommand.Parameters.AddWithValue("@password", hasedPassword);

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

                    // Check if a user record exists
                    if (await reader.ReadAsync())
                    {
                        var storedHash = reader.GetString("PasswordHash");
                        var userId = reader.GetInt32("Id");
                        var role = reader.GetString("Role");

                        // Verify if the provided password matches the stored password hash
                        if (PasswordHasher.VerifyPassword(password, storedHash))
                        {
                            return JwtHelper.GenerateToken(userId, email, role, configuration);
                        }
                        else
                        {
                            return "Invalid credentials";  // Password did not match
                        }
                    }
                    else
                    {
                        return "Invalid credentials";  // No user found
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Error occurred during authentication"; // Return error message
            }
            finally
            {
                await mySqlConnection.CloseAsync();
                await mySqlConnection.DisposeAsync();
            }
        }


    }
}

