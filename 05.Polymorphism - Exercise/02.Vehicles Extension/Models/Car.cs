namespace Vehicles
{
    using System;

    public class Car : Vehicle
    {
        private const double AcConsumptionMod = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm + AcConsumptionMod,tankCapacity)
        {
        }

        protected override double FuelQuantity
        {
            set
            {
                if (value > this.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit in tank");
                }

                base.FuelQuantity = value;
            }
        }
    }
}
