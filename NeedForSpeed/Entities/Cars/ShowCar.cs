using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed.Entities.Cars
{
    public class ShowCar : Car
    {
        private int stars;

        public ShowCar(String brand, String model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        
            :base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
        { 
            this.Stars = 0;
        }

        public int Stars
        {
            get { return this.stars; }
            set { this.stars = value; }
        }

       
        public override void Tune(int tuneIndex, String tuneAddOn)
        {
            base.Tune(tuneIndex, tuneAddOn);
            this.Stars = this.Stars + tuneIndex;
        }

        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append(string.Format("{0} *", this.Stars));

            return result.ToString();
        }
    }
}
