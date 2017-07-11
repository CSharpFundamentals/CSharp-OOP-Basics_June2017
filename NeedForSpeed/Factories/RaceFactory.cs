using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeedForSpeed.Entities.Races.NormalRaces;
using NeedForSpeed.Entities.Races.SpecialRaces;

namespace NeedForSpeed.Factories
{
    public class RaceFactory
    {
        private RaceFactory() { }

        public static CasualRace MakeCasualRace(int length, String route, int prizePool)
        {
            return new CasualRace(length, route, prizePool);
        }

        public static DragRace MakeDragRace(int length, String route, int prizePool)
        {
            return new DragRace(length, route, prizePool);
        }

        public static DriftRace MakeDriftRace(int length, String route, int prizePool)
        {
            return new DriftRace(length, route, prizePool);
        }

        public static TimeLimitRace MakeTimeLimitRace(int length, String route, int prizePool, int goldTime)
        {
            return new TimeLimitRace(length, route, prizePool, goldTime);
        }

        public static CircuitRace MakeCircuitRace(int length, String route, int prizePool, int laps)
        {
            return new CircuitRace(length, route, prizePool, laps);
        }
    }
}
