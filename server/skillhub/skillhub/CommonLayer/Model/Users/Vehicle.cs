namespace skillhub.CommonLayer.Model.Users
{
    public abstract class Vehicle
    {
        private string _brand; // Encapsulation

        public string Brand
        {
            get => _brand;
            set => _brand = value;
        }

        public string Model { get; set; }

        public abstract string StartEngine(); // Abstraction
    }

}
