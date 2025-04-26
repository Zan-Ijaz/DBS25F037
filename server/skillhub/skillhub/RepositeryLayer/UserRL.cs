using MySqlConnector;
using skillhub.Common_Utilities;
using skillhub.CommonLayer.Model;

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

                // Validate CommandText
                if (string.IsNullOrWhiteSpace(commandText))
                {
                    throw new InvalidOperationException("The SQL query for RegisterUser is not defined or is empty.");
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@userName", request.userName);
                    sqlCommand.Parameters.AddWithValue("@email", request.email);
                    sqlCommand.Parameters.AddWithValue("@password", request.password);

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
    }
}
