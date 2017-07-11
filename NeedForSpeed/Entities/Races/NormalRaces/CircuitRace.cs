using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeedForSpeed.Entities.Cars;
using NeedForSpeed.Utilities;

namespace NeedForSpeed.Entities.Races.NormalRaces
{
    public class CircuitRace : NormalRace
    {
        private int laps;

        public CircuitRace(int length, String route, int prizePool, int laps)
            : base(length, route, prizePool)
        {
            this.Laps = laps;
        }
        
        public int Length
        {
            get { return this.Length * this.Laps; }
        }

        public int Laps
        {
            get { return this.laps; }
            private set { this.laps = value; }
        }
        
        public override void Start()
        {
            List<Car> participantCars = new List<Car>();

            participantCars.AddRange(this.Participants.Values);

            for (int lap = 0; lap < this.Laps; lap++)
            {
                foreach (var participantCar in participantCars)
                {
                    participantCar.breakDown(base.Lenght * base.Lenght);
                }
            }

            int count = 0;

            Dictionary<int, Car> orderedParticipants = this.Participants
                .OrderByDescending(n => n.Value.OverallPerformance)
                .ToDictionary(x => x.Key, x => x.Value);


            foreach (var orderedParticipant in orderedParticipants)
            {
                if (count == Constants.CASUAL_RACE_MAXIMUM_WINNERS)
                {
                    break;
                }

                this.AddWinner(orderedParticipant.Value);
                count++;
            }
        }
        
        protected override int GetPrize(int place)
        {
            int prize = this.PrizePool;

            switch (place)
            {
                case 1:
                    prize = (prize * Constants.CIRCUIT_RACE_FIRST_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
                    break;
                case 2:
                    prize = (prize * Constants.CIRCUIT_RACE_SECOND_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
                    break;
                case 3:
                    prize = (prize * Constants.CIRCUIT_RACE_THIRD_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
                    break;
                case 4:
                    prize = (prize * Constants.CIRCUIT_RACE_FOURTH_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
                    break;
            }

            return prize;
        }
        
        protected override string GetWinningStats()
        {
            StringBuilder result = new StringBuilder();

            int count = 1;

            foreach (var winner in Winners)
            {
                int prize = this.GetPrize(count);
                result.AppendLine(string.Format(
                    $"{count}. {winner.Brand} {winner.Model} {winner.OverallPerformance}PP - ${prize}"));
                count++;
            }

            return result.ToString().Trim();
        }
    }
}
