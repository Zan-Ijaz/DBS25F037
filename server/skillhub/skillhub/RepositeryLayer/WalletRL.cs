using Microsoft.Data.SqlClient;
using MySqlConnector;
using skillhub.Common_Utilities;
using skillhub.CommonLayer.Model;
using skillhub.CommonLayer.Model.Users;
using skillhub.Helpers;
using skillhub.Interfaces.IRepositryLayer;
using skillhub.ServiceLayer;

namespace skillhub.RepositeryLayer
{
    public class WalletRL : IWalletRL
    {
        private readonly IConfiguration configuration;
        private readonly IDbConnectionFactory dbConnectionFactory;

        public WalletRL(IConfiguration configuration, IDbConnectionFactory dbConnectionFactory)
        {
            this.configuration = configuration;
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> MakeWallet(Wallet wallet)
        {
            await using var mySqlConnection = dbConnectionFactory.CreateConnection();

            try
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Open)
            {
                await mySqlConnection.OpenAsync();
            }

            string commandText = SqlQueries.makeWallet;

                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@userID", wallet.userID);
                    sqlCommand.Parameters.AddWithValue("@coinbalance", wallet.coinbalance);
                    sqlCommand.Parameters.AddWithValue("@status", wallet.status);

                    await sqlCommand.ExecuteNonQueryAsync();

                    return true;

                }
            }
                catch (Exception)
                {
                    return false;
                }
}

        public async Task<bool> UpdateWallet(Wallet wallet)
        {
            await using var mySqlConnection = dbConnectionFactory.CreateConnection();
            try
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await mySqlConnection.OpenAsync();
                }

                string commandText = SqlQueries.updateWallet;

                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@walletID", wallet.walletID);
                    sqlCommand.Parameters.AddWithValue("@coinbalance", wallet.coinbalance);
                    sqlCommand.Parameters.AddWithValue("@status", wallet.status);

                    var reader = await sqlCommand.ExecuteNonQueryAsync();
                    return true;
                      
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Wallet> FindWallet(int userId)
        {
            await using var mySqlConnection = dbConnectionFactory.CreateConnection();
            try
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await mySqlConnection.OpenAsync();
                }

                string commandText = SqlQueries.findWallet;

                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@userId", userId);

                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return new Wallet
                            (
                                (int)reader["walletID"],
                                (int)reader["userID"],
                                 Convert.ToSingle(reader["coinbalance"]),
                                (DateTime)reader["lastUpdated"],
                                reader["status"].ToString()
                            );
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    }
