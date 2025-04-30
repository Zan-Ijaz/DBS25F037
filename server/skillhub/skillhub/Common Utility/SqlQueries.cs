using Microsoft.Extensions.Configuration;

namespace skillhub.Common_Utilities
{
    public class SqlQueries
    {
        public static IConfiguration configuration = new ConfigurationBuilder()
            .AddXmlFile("SqlQueries.xml", optional: true, reloadOnChange: true)
            .Build();

        public static string userExist
        {
            get
            {
                return configuration["UserExist"];
            }
        }
        public static string RegisterUser
        {
            get
            {
                return configuration["RegisterUser"];
            }
        }

       
        public static string AuthenticateUser
        {
            get
            {
                return configuration["AuthenticateUser"];
            }
        }
    }
}
