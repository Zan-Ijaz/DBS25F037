using skillhub.CommonLayer.Model.Freelancer;

namespace skillhub.Interfaces
{
    public interface IFreelancerSL
    {
        public Task<bool> AddFreelancerInformation(FreelancerRequest freelancer);
    }
}
