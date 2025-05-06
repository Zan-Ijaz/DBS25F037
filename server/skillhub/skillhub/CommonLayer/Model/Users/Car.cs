namespace skillhub.CommonLayer.Model.Users
{
    public class Car : Vehicle
    {
        public int Seats { get; set; }

        public override string StartEngine() => $"Car {Brand} {Model} engine started.";
    }

}
