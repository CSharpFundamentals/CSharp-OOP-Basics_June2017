public class DragRace : Race
{
    public DragRace(int lenght, string route, int prizePool) 
        : base(lenght, route, prizePool)
    {
    }

    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];

        return (car.HorsePower / car.Acceleration);
    }
}
