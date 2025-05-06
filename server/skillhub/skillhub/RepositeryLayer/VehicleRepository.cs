using skillhub.CommonLayer.Model.Users;

namespace skillhub.RepositeryLayer
{
    public class VehicleRepository : IVehicleRepository
    {
        public List<Vehicle> GetAllVehicles()
        {
            return new List<Vehicle>
        {
            new Car { Brand = "Toyota", Model = "Corolla", Seats = 5 },
            new Bike { Brand = "Honda", Model = "CBR", HasCarrier = false },
            new Truck { Brand = "Ford", Model = "F-150", LoadCapacity = 2000 }
        };
        }
    }
}
