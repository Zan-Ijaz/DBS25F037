using skillhub.RepositeryLayer;

namespace skillhub.ServiceLayer
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public List<string> StartAllEngines()
        {
            var vehicles = _repository.GetAllVehicles();

            List<string> messages = new List<string>();
            foreach (var v in vehicles)
            {
                messages.Add(v.StartEngine()); // Polymorphism
            }

            return messages;
        }
    }
}
