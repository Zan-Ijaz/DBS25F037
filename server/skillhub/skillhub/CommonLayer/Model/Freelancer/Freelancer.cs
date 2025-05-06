using skillhub.CommonLayer.Model.Users;

namespace skillhub.CommonLayer.Model.Freelancer
{
    public class Freelancer : User
    {
        public int freelancerID { get; private set; }

        public int userID { get; private set; }

        public char gender { get; private set; }

        public string education { get; private set; }

        public string language { get; private set; }

        public Freelancer(int userID, char gender, string education, string languaage)
        {
            this.userID = userID;
            this.gender = gender;
            this.education = education;
            this.language = languaage;
        }

    }
}
