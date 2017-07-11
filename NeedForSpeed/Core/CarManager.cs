using NeedForSpeed.Entities.Cars;
using NeedForSpeed.Entities.Essentials;
using NeedForSpeed.Entities.Races;
using NeedForSpeed.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using NeedForSpeed.Factories;

namespace NeedForSpeed.Core
{
    public class CarManager
    {
        private Dictionary<int, Car> cars;
        private Dictionary<int, Race> races;

        private Garage garage;

        public CarManager()
        {
            this.cars = new Dictionary<int, Car>();
            this.races = new Dictionary<int, Race>();
            this.garage = new Garage();
        }

        public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        {
            Car newCar = this.MakeCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

            this.cars.Add(id, newCar);
        }

        public string Check(int id)
        {
            Car foundCar = this.cars[id];

            return foundCar.ToString();
        }

        public void Open(int id, string type, int length, string route, int prizePool)
        {
            Race newRace = this.MakeRace(type, length, route, prizePool);

            this.races.Add(id, newRace);
        }

        public void Open(int id, string type, int length, string route, int prizePool, int specialRaceParameter)
        {
            Race newRace = this.MakeRace(type, length, route, prizePool, specialRaceParameter);

            this.races.Add(id, newRace);
        }

        public void Participate(int carId, int raceId)
        {
            if (!this.IsParked(carId))
            {
                this.races[raceId].AddParticipant(carId, this.cars[carId]);
            }
        }

        public string Start(int id)
        {
            string raceResult = String.Empty;

            if (this.races[id].Participants.Count > 0)
            {
                Race currentRace = this.races[id];
                this.races.Remove(id);
                currentRace.Start();
                raceResult = currentRace.ToString();
            }
            else
            {
                raceResult = Constants.RACE_HAS_NO_PARTICIPANTS_MESSAGE;
            }

            return raceResult;
        }

        public void Park(int id)
        {
            if (!this.IsRacer(id))
            {
                Car parkedCar = this.cars[id];
                this.garage.Park(id, parkedCar);
            }
        }

        public void Unpark(int id)
        {
            if (this.IsParked(id))
            {
                this.garage.Unpark(id);
            }
        }

        public void tune(int tuneIndex, string addOn)
        {
            this.garage.Tune(tuneIndex, addOn);
        }

        private Car MakeCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        {
            Car resultCar = null;

            switch (type)
            {
                case "Performance":
                    resultCar = CarFactory.MakePerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                    break;

                case "Show":
                    resultCar = CarFactory.MakeShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                    break;
            }

            return resultCar;
        }

        private Race MakeRace(string type, int length, string route, int prizePool)
        {
            Race resultRace = null;

            switch (type)
            {
                case "Casual":
                    resultRace = RaceFactory.MakeCasualRace(length, route, prizePool);
                    break;

                case "Drag":
                    resultRace = RaceFactory.MakeDragRace(length, route, prizePool);
                    break;

                case "Drift":
                    resultRace = RaceFactory.MakeDriftRace(length, route, prizePool);
                    break;
            }

            return resultRace;
        }

        private Race MakeRace(string type, int length, string route, int prizePool, int specialRaceParameter)
        {
            Race resultRace = null;

            switch (type)
            {
                case "TimeLimit":
                    resultRace = RaceFactory.MakeTimeLimitRace(length, route, prizePool, specialRaceParameter);
                    break;

                case "Circuit":
                    resultRace = RaceFactory.MakeCircuitRace(length, route, prizePool, specialRaceParameter);
                    break;
            }

            return resultRace;
        }

        private bool IsRacer(int id)
        {
            return this.races.Values.Any(x => x.Participants.ContainsKey(id));
        }

        private bool IsParked(int id)
        {
            return this.garage.IsParked(id);
        }
    }
}