using NeedForSpeed.Entities.Cars;
using System.Collections.Generic;

namespace NeedForSpeed.Entities.Essentials
{
    public class Garage
    {
        private Dictionary<int, Car> parkedCars;

        public Garage()
        {
            this.parkedCars = new Dictionary<int, Car>();
        }

        public void Park(int id, Car car)
        {
            this.parkedCars.Add(id, car);
        }

        public void Unpark(int id)
        {
            this.parkedCars.Remove(id);
        }

        public bool IsParked(int id)
        {
            return this.parkedCars.ContainsKey(id);
        }

        //WTF
        public void Tune(int tuneIndex, string addOn)
        {
            foreach (var parkedCar in this.parkedCars)
            {
                parkedCar.Value.Tune(tuneIndex, addOn);
            }
        }
    }
}