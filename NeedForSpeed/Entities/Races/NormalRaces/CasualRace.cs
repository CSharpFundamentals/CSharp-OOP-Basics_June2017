using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeedForSpeed.Entities.Cars;
using NeedForSpeed.Utilities;

namespace NeedForSpeed.Entities.Races.NormalRaces
{
    public class CasualRace : NormalRace
    {
        public CasualRace(int length, String route, int prizePool)
            : base(length, route, prizePool)
        {
        }
        

        public override void Start()
        {
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
