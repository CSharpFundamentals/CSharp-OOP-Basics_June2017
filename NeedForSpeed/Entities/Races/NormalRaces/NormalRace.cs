using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeedForSpeed.Utilities;

namespace NeedForSpeed.Entities.Races.NormalRaces
{
    public abstract class NormalRace : Race
    {
        protected NormalRace(int length, String route, int prizePool)
            : base(length, route, prizePool) { }

        protected override int GetPrize(int place)
        {
            int prize = this.PrizePool;

            switch (place)
            {
                case 1:
                    prize = (prize * Constants.NORMAL_RACE_FIRST_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
                    break;
                case 2:
                    prize = (prize * Constants.NORMAL_RACE_SECOND_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
                    break;
                case 3:
                    prize = (prize * Constants.NORMAL_RACE_THIRD_PLACE_PRIZE_PERCENTAGE) / Constants.MAXIMUM_PERCENTAGE;
                    break;
            }

            return prize;
        }

        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append(this.GetWinningStats());

            return result.ToString();
        }
    }
}
