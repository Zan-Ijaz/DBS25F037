using Azure;
using System;
using Microsoft.AspNetCore.Mvc;
using skillhub.Interfaces.IServiceLayer;
using skillhub.CommonLayer.Model;
using skillhub.Models;

namespace skillhub.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class MessagesController : Controller
        {
            private readonly IMessageSL messageInterface;

            public MessagesController(IMessageSL messageInterface)
            {
                this.messageInterface = messageInterface;
            }

            [HttpPost("send")]
            public async Task<IActionResult> SendMessage(MessageRequest request)
            {
                try
                {
                
                    var response = await messageInterface.SendMessage(request);

                    return Ok(new { message = "Message sent", data = response });
            }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        [HttpDelete("deleteMessage/{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageid)
        {
            try
            {
                var response = await messageInterface.DeleteMessage(messageid);

                return Ok(new { message = "Message sent", data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
