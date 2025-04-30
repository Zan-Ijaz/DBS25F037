using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skillhub.CommonLayer.Model.Users;
using skillhub.Interfaces;

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
                if (!response.isSuccess)
                {

                    return BadRequest(new { message = response.message });
                }
                // Return a successful response with a message
                return Ok(new { message = "User registered successfully", data = response });
            }
            catch (Exception ex)
            {

                response.isSuccess = false;
                response.message = ex.Message;
                return BadRequest(new { isSuccess = response.isSuccess, message = $"Error: {ex.Message}" });

            }
            return Ok(new { isSuccess = response.isSuccess, messaage = response.message });
        }

        [HttpPost("login")]
        public async Task<IActionResult> ActionResult(string email, string password)
        {
            try
            {
                string token = await userInterface.AuthenticateUser(email, password);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
