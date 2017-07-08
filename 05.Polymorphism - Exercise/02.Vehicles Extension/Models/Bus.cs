namespace Vehicles.Models
{
    using System;

    public class Bus : Vehicle
    {
        private const double AcConsumptionMod = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        protected override double FuelQuantity
        {
            set
            {
                if (value > this.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }

                base.FuelQuantity = value;
            }
        }

        protected override bool Drive(double distance, bool isAcOn)
        {
            double requiredFuel = 0;
            if (isAcOn)
            {
                requiredFuel = distance * (this.FuelConsumptionPerKm + AcConsumptionMod);
            }
            else
            {
                requiredFuel = distance * this.FuelConsumptionPerKm;
            }

            if (requiredFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= requiredFuel;
                return true;
            }

            return false;
        }
    }
}
