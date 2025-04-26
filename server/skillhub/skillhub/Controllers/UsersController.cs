using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skillhub.CommonLayer.Model;
using skillhub.ServiceLayer;

namespace skillhub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly UserInterfaceSL userInterface;

        public UsersController(UserInterfaceSL userInterface)
        {
            this.userInterface = userInterface;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUserRegister(UserRegisterRequest request)
        {
            UserRegisterResponse response = new UserRegisterResponse();

            try
            {
                response = await userInterface.AddUserRegister(request);
                // Return a successful response with a message
                return Ok(new { message = "User registered successfully", data = response });
            }
            catch (Exception ex)
            {
                // Return a failure response with an error message
                return BadRequest(new { message = $"Error: {ex.Message}" });
            }
        }
    }
}
