namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AcConsumptionMod = 1.6;
        private const double FuelLossFactor = 0.95;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm + AcConsumptionMod)
        {}

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * FuelLossFactor);
        }
    }
}
