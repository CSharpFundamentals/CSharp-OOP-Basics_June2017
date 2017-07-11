using NeedForSpeed.Entities.Cars;
using System;

namespace NeedForSpeed.Factories
{
    public class CarFactory
    {
        private CarFactory()
        {
        }

        public static PerformanceCar MakePerformanceCar(String brand, String model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        {
            return new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }

        public static ShowCar MakeShowCar(String brand, String model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        {
            return new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }
    }
}