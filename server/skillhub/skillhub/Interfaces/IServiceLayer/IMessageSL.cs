using skillhub.CommonLayer.Model;

namespace skillhub.Interfaces.IServiceLayer
{
    public interface IMessageSL
    {
        public Task<bool> SendMessage(MessageRequest request);
        public Task<bool> DeleteMessage(int messageid);

    }
}
