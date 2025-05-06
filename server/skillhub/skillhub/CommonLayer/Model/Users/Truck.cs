namespace skillhub.CommonLayer.Model.Users
{
    public class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }

        public override string StartEngine() => $"Truck {Brand} {Model} engine started.";
    }
}
