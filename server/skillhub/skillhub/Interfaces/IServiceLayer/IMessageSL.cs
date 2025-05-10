using skillhub.CommonLayer.Model;
using skillhub.Models;

namespace skillhub.Interfaces.IServiceLayer
{
    public interface IMessageSL
    {
        public Task<bool> SendMessage(MessageRequest request);
        public Task<bool> DeleteMessage(int messageid);
        public Task<List<Message>> RetriveMessagebySender(int senderid);
        public Task<List<Message>> RetriveMessagebyReceiver(int receiverid);

    }
}
