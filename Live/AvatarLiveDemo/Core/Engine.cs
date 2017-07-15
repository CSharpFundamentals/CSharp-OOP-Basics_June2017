using System;
using System.Linq;

public class Engine
{
    private string input;
    private bool isRunning;
    private NationsBuilder builder;

    public Engine()
    {
        this.builder = new NationsBuilder();
        isRunning = true;
    }

    public void Run()
    {
        while (isRunning)
        {
            var cmdArgs = Console.ReadLine().Split(' ').ToList();
            var command = cmdArgs[0];
            cmdArgs.RemoveAt(0);

            switch (command)
            {
                case "Bender":
                    builder.AssignBender(cmdArgs);
                    break;
                case "Monument":
                    builder.AssignMonument(cmdArgs);
                    break;
                case "Status":
                    Console.WriteLine(builder.GetStatus(cmdArgs[0]));
                    break;
                case "War":
                    builder.IssueWar(cmdArgs[0]);
                    break;
                case "Quit":
                    Console.WriteLine(builder.GetWarsRecord());
                    isRunning = false;
                    break;
            }
        }
    }
}
