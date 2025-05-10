using skillhub.CommonLayer.Model;
using skillhub.Models;

namespace skillhub.Interfaces.IRepositryLayer
{
    public interface IMessageRL
    {
        public Task<bool> SendMessage(Message message);
        public Task<bool> DeleteMessage(int messageid);
        public Task<List<Message>> RetriveMessagebySender(int senderid);
        public Task<List<Message>> RetriveMessagebyReceiver(int receiverid);
    }
}
