using System.ComponentModel.DataAnnotations;

namespace skillhub.CommonLayer.Model.Users
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string userName { get; set; }
        public int roleID { get; set; }

       
    }

            
}

