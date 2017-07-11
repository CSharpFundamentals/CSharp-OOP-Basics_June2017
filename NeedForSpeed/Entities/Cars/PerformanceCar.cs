using NeedForSpeed.Utilities;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Entities.Cars
{
    public class PerformanceCar : Car
    {
        private List<string> addOns;

        public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
            : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
        {
            this.modifyStats();
            this.addOns = new List<string>();
        }

        public IReadOnlyList<string> AddOns
        {
            get { return this.addOns.AsReadOnly(); }
        }

        private void modifyStats()
        {
            this.Horsepower = this.Horsepower +
                              this.Horsepower *
                              Constants.PERFORMANCE_CAR_HORSEPOWER_PERCENTAGE_MODIFIER /
                              Constants.MAXIMUM_PERCENTAGE;
            this.Suspension = this.Suspension -
                              this.Suspension *
                              Constants.PERFORMANCE_CAR_SUSPENSION_PERCENTAGE_MODIFIER /
                              Constants.MAXIMUM_PERCENTAGE;
        }

        public override void Tune(int tuneIndex, string tuneAddOn)
        {
            base.Tune(tuneIndex, tuneAddOn);

            this.addOns.Add(tuneAddOn);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append(string.Format("Add-ons: {0}", this.AddOns.Count > 0 ? string.Join(", ", this.AddOns) : "None"));

            return result.ToString();
        }
    }
}