namespace Pizza
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private int numberOfToppings;

        public Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
            this.NumberOfToppings = numberOfToppings;
        }

        public Dough Dough
        {
            //FIX set { this.Dough = value; } - ends up in recurcive call
            set { this.dough = value; }
        }
        public int NumberOfToppings
        {
            get { return this.numberOfToppings; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                this.numberOfToppings = value;
            }
        }

        
        public string Name
        {
            get { return this.name; }
            set {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value; }
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        }
    }
}
