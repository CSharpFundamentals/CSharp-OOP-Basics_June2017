using System.Text;
using NeedForSpeed.Utilities;

namespace NeedForSpeed.Entities.Cars
{
    public abstract class Car
    {
        private string brand;
        private string model;
        private int yearOfProduction;

        private int horsepower;
        private int acceleration;

        private int suspension;
        private int durability;

        protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration,
            int suspension, int durability)
        {
            this.Brand = brand;
            this.Model = model;
            this.YearOfProduction = yearOfProduction;

            this.Horsepower = horsepower;
            this.Acceleration = acceleration;
            this.Suspension = suspension;
            this.Durability = durability;
        }

        public string Brand
        {
            get { return this.brand; }
            set { this.brand = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int YearOfProduction
        {
            get { return this.yearOfProduction; }
            set { this.yearOfProduction = value; }
        }

        public int Horsepower
        {
            get { return this.horsepower; }
            set { this.horsepower = value; }
        }

        public int Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        public int Suspension
        {
            get { return this.suspension; }
            set { this.suspension = value; }
        }

        public int Durability
        {
            get { return this.durability; }
            set { this.durability = value; }
        }

        public int EnginePerformance
        {
            get
            {
                int enginePerformance = this.Horsepower / this.Acceleration;
                return enginePerformance;
            }
        }

        public int SuspensionPerformance
        {
            get
            {
                int suspensionPerformance = this.Suspension + this.Durability;
                return suspensionPerformance;
            }
        }

        public int OverallPerformance
        {
            get
            {
                int overallPerformance = EnginePerformance + SuspensionPerformance;
                return overallPerformance;
            }
        }

        public virtual void Tune(int tuneIndex, string tuneAddOn)
        {
            this.Horsepower = this.Horsepower + tuneIndex;
            this.Suspension = this.Suspension + tuneIndex / Constants.TUNING_SUSPENSION_MODIFIER;
        }

        public void breakDown(int lapLength)
        {
            this.Durability = this.Durability - lapLength;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format($"{this.Brand} {this.Model} {this.YearOfProduction}\r\n"));
            result.Append(string.Format($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s\r\n"));
            result.Append(string.Format($"{this.Suspension} Suspension force, {this.Durability} Durability\r\n"));

            return result.ToString();
        }
    }
}