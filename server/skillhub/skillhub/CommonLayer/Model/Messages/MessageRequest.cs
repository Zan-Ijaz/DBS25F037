﻿
namespace skillhub.CommonLayer.Model
{
    public class MessageRequest
    {
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public string messageText { get; set; }
    }

}
