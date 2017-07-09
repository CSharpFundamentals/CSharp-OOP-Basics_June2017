namespace MordorsCrueltyPlan.Models
{
    public abstract class Food
    {
        protected Food(int hapinessPoints)
        {
            this.HapinessPoints = hapinessPoints;
        }
        private int HapinessPoints { get; set; }

        public int GetHapinessPoints()
        {
            return this.HapinessPoints;
        }
    }
}
