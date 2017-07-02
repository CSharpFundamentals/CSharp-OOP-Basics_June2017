namespace Pizza
{
    using System;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < MinWeight || value > MaxWeight )
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                this.weight = value;
            }
        }


        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        
        public string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (value.ToLower() != "wholegrain" && value.ToLower() != "white")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public double GetCalories()
        {
            return 2 * this.Weight * this.GetTechMod() * this.GetTypeMod();
        }

        private double GetTypeMod()
        {
            if (this.FlourType.ToLower() == "white")
            {
               return 1.5;
            }

            return 1;
        }

        private double GetTechMod()
        {
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }

            return 1;
        }
        
    }
}
