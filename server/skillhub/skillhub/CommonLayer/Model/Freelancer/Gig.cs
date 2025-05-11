using skillhub.CommonLayer.Model;

namespace skillhub.CommonLayer.Model.Gigs
{
    public class Gig
    {
        public int gigId { get; private set; }
        public int userId { get; private set; }
        public string title { get; private set; }
        public string description { get; private set; }
        public int categoryId { get; private set; }
        public float rating { get; private set; }
        public DateTime createdAt { get; private set; }
        public DateTime UpdatedDate { get; private set; }

        public Gig(
            int userId,
            string title,
            string description,
            int categoryId)
        {

            this.userId = userId;
            this.title = title;
            this.description = description;
            this.categoryId = categoryId;


        }
        public Gig(int gigId, int userId, string title, string description, int categoryId, float rating, DateTime createdAt, DateTime updatedDate)
        {
            this.gigId = gigId;
            this.userId = userId;
            this.title = title;
            this.description = description;
            this.categoryId = categoryId;
            this.rating = rating;
            this.createdAt = createdAt;
            UpdatedDate = updatedDate;
        }
    }
}
