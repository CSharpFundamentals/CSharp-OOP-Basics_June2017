namespace WildFarm.Models.Animals
{
    public class Cat : Felime
    {
        public Cat(string name, string type, double weight, string livingRegion, string breed) : base(name, type, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }
        public override string MakeSound()
        {
            return "Meowwww";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
