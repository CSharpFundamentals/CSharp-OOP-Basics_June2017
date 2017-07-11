using NeedForSpeed.Entities.Cars;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Entities.Races
{
    public abstract class Race
    {
        private int length;
        private string route;
        private int prizePool;
        private Dictionary<int, Car> participants;
        private List<Car> winners;

        protected Race(int length, string route, int prizePool)
        {
            this.Lenght = length;
            this.Route = route;
            this.PrizePool = prizePool;

            this.participants = new Dictionary<int, Car>();
            this.winners = new List<Car>();
        }

        protected IReadOnlyList<Car> Winners
        {
            get { return this.winners.AsReadOnly(); }
        }

        public int Lenght
        {
            get { return this.length; }
            set { this.length = value; }
        }

        public string Route
        {
            get { return this.route; }
            set { this.route = value; }
        }

        public int PrizePool
        {
            get { return this.prizePool; }
            set { this.prizePool = value; }
        }

        public Dictionary<int, Car> Participants
        {
            get { return this.participants; }
        }

        public abstract void Start();

        protected abstract int GetPrize(int place);

        protected abstract string GetWinningStats();

        public void AddParticipant(int carId, Car car)
        {
            this.participants.Add(carId, car);
        }

        protected void AddWinner(Car winner)
        {
            this.winners.Add(winner);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format($"{this.Route} - {this.Lenght}\r\n"));

            return result.ToString();
        }
    }
}