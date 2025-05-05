using MySqlConnector;

namespace skillhub.Helpers
{
    public interface IDbConnectionFactory
    {
        MySqlConnection CreateConnection();
    }
}
