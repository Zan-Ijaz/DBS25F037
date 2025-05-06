using System.Data.Common;
using Azure;
using MySqlConnector;
using skillhub.Common_Utilities;
using skillhub.CommonLayer.Model.Freelancer;
using skillhub.Helpers;
using skillhub.Interfaces.IRepositryLayer;

namespace skillhub.RepositeryLayer
{
    public class FreelancerRL : IFreelancerRL
    {
        private readonly IConfiguration configuration;
        private readonly IDbConnectionFactory dbConnectionFactory;

        public FreelancerRL(IConfiguration configuration, IDbConnectionFactory dbConnectionFactory)
        {
            this.configuration = configuration;
            this.dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> AddFreelancerInformation(Freelancer freelancer)
        {
            await using var mySqlConnection = dbConnectionFactory.CreateConnection();

            try
            {
                if(mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await mySqlConnection.OpenAsync();
                }

                string commandText = SqlQueries.freelancerInformation;

                using (MySqlCommand sqlCommand = new MySqlCommand(commandText, mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;

                    sqlCommand.Parameters.AddWithValue("@userID", freelancer.userID);
                    sqlCommand.Parameters.AddWithValue("@gender", freelancer.gender);
                    sqlCommand.Parameters.AddWithValue("@education", freelancer.education);
                    sqlCommand.Parameters.AddWithValue("@language", freelancer.language);

                    await sqlCommand.ExecuteNonQueryAsync();

                    return true;

                }                


            }
            catch (Exception ex) 
            {
                return false;
            }
            

        }
    }
}
