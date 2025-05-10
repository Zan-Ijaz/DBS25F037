﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace skillhub.Common_Utilities
{
    public class SqlQueries
    {
        public static IConfiguration configuration = new ConfigurationBuilder()
            .AddXmlFile("SqlQueries.xml", optional: true, reloadOnChange: true)
            .Build();

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

        public static string emailExists
        {
            get
            {
                return configuration["emailExists"];
            }
        }

        public static string userNameExists
        {
            get
            {
                return configuration["userNameExists"];
            }
        }

        public static string freelancerInformation
        {
            get
            {
                return configuration["FreelancerInformation"];
            }
        }
        public static string sendmessage 
        { get
            {
                return configuration["SendMessage"];
            } 
        }
        public static string makeWallet
        {
            get
            {
                return configuration["MakeWallet"];
            }
        }
        public static string deleteMessage
        {
            get
            {
                return configuration["DeleteMessage"];
            }

        }
        public static string deleteWallet
        {
            get
            {
                return configuration["DeleteWallet"];
            }

        }
        public static string blockUser
        {
            get
            {
                return configuration["BlockUser"];
            }
        }
        public static string unblockUser
        {
            get
            {
                return configuration["Unblock"];
            }
        }
        public static string FindUser 
        { 
            get
            { 
                return configuration["FindUser"];
            }
        }




    }
}
