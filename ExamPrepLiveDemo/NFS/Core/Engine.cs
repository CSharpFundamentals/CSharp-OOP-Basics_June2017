using System;

public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.manager = new CarManager();
    }

    public void Run()
    {
        string command = String.Empty;

        while ((command = Console.ReadLine()) != "Cops Are Here")
        {
            var cmdArg = command.Split(' ');
            ExecuteCommand(cmdArg);
        }
    }

    public void ExecuteCommand(string[] cmdArgs)
    {
        int id;
        string type;
        int raceId;

        switch (cmdArgs[0])
        {
            case "register":
                id = int.Parse(cmdArgs[1]);
                type = cmdArgs[2];
                string brand = cmdArgs[3];
                string model = cmdArgs[4];
                int yearOfProduction = int.Parse(cmdArgs[5]);
                int horsepower = int.Parse(cmdArgs[6]);
                int acceleration = int.Parse(cmdArgs[7]);
                int suspension = int.Parse(cmdArgs[8]);
                int durability = int.Parse(cmdArgs[9]);
                manager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            case "check":
                Console.WriteLine(manager.Check(int.Parse(cmdArgs[1])));
                break;
            case "open":
                id = int.Parse(cmdArgs[1]);
                type = cmdArgs[2];
                int lenght = int.Parse(cmdArgs[3]);
                string route = cmdArgs[4];
                int pricePool = int.Parse(cmdArgs[5]);
                manager.Open(id, type, lenght, route, pricePool);
                break;
            case "participate":
                int carId = int.Parse(cmdArgs[1]);
                raceId = int.Parse(cmdArgs[2]);
                manager.Participate(carId, raceId);
                break;
            case "start":
                raceId = int.Parse(cmdArgs[1]);
                Console.WriteLine(manager.Start(raceId));
                break;
            case "park":
                id = int.Parse(cmdArgs[1]);
                manager.Park(id);
                break;
            case "unpark":
                id = int.Parse(cmdArgs[1]);
                manager.Unpark(id);
                break;
            case "tune":
                int tuneIndex = int.Parse(cmdArgs[1]);
                string addon = cmdArgs[2];
                manager.Tune(tuneIndex, addon);
                break;
        }
    }
}