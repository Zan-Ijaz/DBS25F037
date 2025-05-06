namespace skillhub.CommonLayer.Model.Users
{
    public class Bike : Vehicle
    {
        public bool HasCarrier { get; set; }

        public override string StartEngine() => $"Bike {Brand} {Model} engine started.";
    }
}
