using Microsoft.AspNetCore.Mvc;
using skillhub.RepositeryLayer;
using skillhub.ServiceLayer;

namespace skillhub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController()
        {
            // Normally, use DI here. For simplicity, manual initialization:
            IVehicleRepository repo = new VehicleRepository();
            _vehicleService = new VehicleService(repo);
        }

        [HttpGet("start-engines")]
        public IActionResult StartEngines()
        {
            var results = _vehicleService.StartAllEngines();
            return Ok(results);
        }
    }
}
