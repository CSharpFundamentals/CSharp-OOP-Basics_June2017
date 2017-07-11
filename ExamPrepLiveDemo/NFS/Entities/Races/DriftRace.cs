public class DriftRace : Race
{
    public DriftRace(int lenght, string route, int prizePool) 
        : base(lenght, route, prizePool)
    {
    }

    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];

        return (car.Suspension + car.Durability);
    }
}
