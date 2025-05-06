using skillhub.CommonLayer.Model.Freelancer;

namespace skillhub.Interfaces
{
    public interface IFreelancerRL
    {
        public Task<bool> AddFreelancerInformation(Freelancer freelancer);
    }
}
