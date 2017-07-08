namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AcConsumptionMod = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm + AcConsumptionMod)
        {
        }
    }
}
