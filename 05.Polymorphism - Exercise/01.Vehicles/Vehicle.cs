namespace Vehicles
{
    using System.Globalization;

    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        private double FuelQuantity { get; set; }

        private double FuelConsumptionPerKm { get; set; }

        private bool Drive(double distance)
        {
            var fuelRequired = distance * this.FuelConsumptionPerKm;
            if (fuelRequired <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelRequired;
                return true;
            }

            return false;
        }

        public string TryTravelDistance(double distance)
        {
            if (this.Drive(distance))
            {
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuelAmount) 
            => this.FuelQuantity += fuelAmount;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
