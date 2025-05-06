using skillhub.CommonLayer.Model.Users;

namespace skillhub.RepositeryLayer
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
    }
}
