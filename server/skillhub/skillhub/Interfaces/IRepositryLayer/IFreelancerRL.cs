using skillhub.CommonLayer.Model.Freelancer;

namespace skillhub.Interfaces.IRepositryLayer
{
    public interface IFreelancerRL
    {
        public Task<bool> AddFreelancerInformation(Freelancer freelancer);
    }
}
