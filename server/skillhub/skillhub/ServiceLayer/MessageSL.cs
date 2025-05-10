using skillhub.CommonLayer.Model;
using skillhub.CommonLayer.Model.Freelancer;
using skillhub.Interfaces.IRepositryLayer;
using skillhub.Interfaces.IServiceLayer;
using skillhub.Models;

namespace skillhub.RepositeryLayer
{
    public class MessageSL : IMessageSL
    {
        public readonly IMessageRL messageInterface;
        public readonly UserInterfaceSL userInterface;
        public MessageSL(IMessageRL messageInterface,UserInterfaceSL userInterface)
        {
            this.messageInterface = messageInterface;
            this.userInterface = userInterface;
        }

        public Task<bool> DeleteMessage(int messageid)
        {
            return messageInterface.DeleteMessage(messageid);
        }

        public Task<List<Message>> RetriveMessagebyReceiver(int receiverid)
        {
            return messageInterface.RetriveMessagebyReceiver(receiverid);
        }

        public Task<List<Message>> RetriveMessagebySender(int senderid)
        {
            return messageInterface.RetriveMessagebySender(senderid);
        }

        public async Task<bool> SendMessage(MessageRequest request)
        {
            Message message = new Message(request.senderId,request.receiverId, request.messageText);
            return await messageInterface.SendMessage(message);
        }

    }
}
