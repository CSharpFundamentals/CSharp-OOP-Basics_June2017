using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeedForSpeed.Entities.Cars;
using NeedForSpeed.Utilities;

namespace NeedForSpeed.Entities.Races.SpecialRaces
{
    public class TimeLimitRace : Race
    {
        private int goldTime;

        public TimeLimitRace(int length, String route, int prizePool, int goldTime)
        
            :base(length, route, prizePool)
        {
            this.GoldTime = goldTime;
        }

        public int GoldTime
        {
            get { return this.goldTime; }
            set { this.goldTime = value; }
        }

        public void AddParticipant(int carId, Car car)
        {
            if (this.Participants.Count == 0)
            {
                base.AddParticipant(carId, car);
            }
        }
        
        public override void Start()
        {
            foreach (var participant in this.Participants)
            {
                this.AddWinner(participant.Value);
            }
        }

        private int GetTime(Car winner)
        {
            return base.Lenght * ((winner.Horsepower / 100) * winner.Acceleration);
        }

        private String GetTimeClassification(int time)
        {
            String result = String.Empty;

            if (time <= this.GoldTime)
            {
                result = "Gold";
            }
            else if (time <= this.GoldTime + Constants.TIME_LIMIT_RACE_SILVER_TIME_SECONDS_OFFSET)
            {
                result = "Silver";
            }
            else if (time > this.GoldTime + Constants.TIME_LIMIT_RACE_SILVER_TIME_SECONDS_OFFSET)
            {
                result = "Bronze";
            }

            return result;
        }

        private int GetPlace(String winnerTimeClassification)
        {
            int place = 0;

            switch (winnerTimeClassification)
            {
                case "Gold":
                    place = 1;
                    break;
                case "Silver":
                    place = 2;
                    break;
                case "Bronze":
                    place = 3;
                    break;
            }

            return place;
        }

        protected override string GetWinningStats()
        {
            StringBuilder result = new StringBuilder();

            Car winner = this.Winners[0];
            int winnerTime = this.GetTime(winner);
            String winnerTimeClassification = this.GetTimeClassification(winnerTime);
            int place = this.GetPlace(winnerTimeClassification);
            int prize = this.GetPrize(place);

            result.AppendLine(String.Format($"{winner.Brand} {winner.Model} - {winnerTime} s."));
            result.AppendLine(String.Format($"{winnerTimeClassification} Time, ${prize}."));

            return result.ToString();
        }
        
        protected override int GetPrize(int place)
        {
            int result = this.PrizePool;

            if (place == 1)
            {
                result = (result * Constants.TIME_LIMIT_RACE_FIRST_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
            }
            else if (place == 2)
            {
                result = (result * Constants.TIME_LIMIT_RACE_SECOND_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
            }
            else if (place == 3)
            {
                result = (result * Constants.TIME_LIMIT_RACE_THIRD_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
            }

            return result;
        }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append(this.GetWinningStats());

            return result.ToString();
        }
    }
}
