using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeedForSpeed.IO;
using NeedForSpeed.Utilities;

namespace NeedForSpeed.Core
{
    public class Engine
    {
        private ConsoleReader inputReader;

        private ConsoleWriter outputWriter;

        private InputParser inputParser;

        private CarManager carManager;

        public Engine()
        {
            this.inputReader = new ConsoleReader();
            this.outputWriter = new ConsoleWriter();
            this.inputParser = new InputParser();
            this.carManager = new CarManager();
        }

        public void Run()
        {
            string inputLine = String.Empty;

            while (!(inputLine = this.inputReader.ReadLine()).Equals(Constants.INPUT_TERMINATING_COMMAND))
            {
                List<String> commandParams = this.inputParser.parseInput(inputLine);

                this.dispatchCommand(commandParams);
            }
        }

        private void dispatchCommand(List<string> commandParams)
        {
            string command = commandParams[0];
            commandParams.Remove(command);

            switch (command)
            {
                case "register":
                    int registerId = int.Parse(commandParams[0]);
                    string registerType = commandParams[1];

                    string brand = commandParams[2];
                    string model = commandParams[3];
                    int yearOfProduction = int.Parse(commandParams[4]);

                    int horsepower = int.Parse(commandParams[5]);
                    int acceleration = int.Parse(commandParams[6]);
                    int suspension = int.Parse(commandParams[7]);
                    int durability = int.Parse(commandParams[8]);

                    this.carManager.Register(registerId, registerType, brand, model, yearOfProduction, horsepower,
                        acceleration, suspension, durability);
                    break;
                case "check":
                    int checkId = int.Parse(commandParams[0]);

                    this.outputWriter.WriteLine(this.carManager.Check(checkId));
                    break;
                case "open":
                    int openId = int.Parse(commandParams[0]);
                    string openType = commandParams[1];

                    int length = int.Parse(commandParams[2]);
                    string route = commandParams[3];
                    int prizePool = int.Parse(commandParams[4]);

                    if (commandParams.Count > 5)
                    {
                        int specialRaceParameter = int.Parse(commandParams[5]);
                        this.carManager.Open(openId, openType, length, route, prizePool, specialRaceParameter);
                    }
                    else
                    {
                        this.carManager.Open(openId, openType, length, route, prizePool);
                    }

                    break;
                case "participate":
                    int carId = int.Parse(commandParams[0]);
                    int raceId = int.Parse(commandParams[1]);

                    this.carManager.Participate(carId, raceId);
                    break;
                case "start":
                    int startId = int.Parse(commandParams[0]);

                    this.outputWriter.WriteLine(this.carManager.Start(startId));
                    break;
                case "park":
                    int parkId = int.Parse(commandParams[0]);

                    this.carManager.Park(parkId);
                    break;
                case "unpark":
                    int unparkId = int.Parse(commandParams[0]);

                    this.carManager.Unpark(unparkId);
                    break;
                case "tune":
                    int tuneIndex = int.Parse(commandParams[0]);
                    string addOn = commandParams[1];

                    this.carManager.tune(tuneIndex, addOn);
                    break;
            }
        }
    }
}
