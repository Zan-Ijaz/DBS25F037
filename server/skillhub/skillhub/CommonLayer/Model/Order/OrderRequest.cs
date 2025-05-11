using skillhub.CommonLayer.Model.Gigs;

namespace skillhub.CommonLayer.Model.Order
{
    public class OrderRequest
    {
        public int clientId { get; private set; }
        public int gigId { get; private set; }
        public int freelancerId { get; private set; }
        public DateTime dueDate { get; private set; }
        public float coinAmount { get; private set; }
    }
}
