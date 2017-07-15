using System;
public abstract class Bender
{
    public string Name { get; }

    public int Power { get; }

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public abstract double GetTotalPower();

    public override string ToString()
    {
        var name = this.GetType().Name;
        var index = name.IndexOf("Bender");
        name = name.Insert(index, " ");

        return $"###{name}: {this.Name}, Power: {this.Power},";
    }
}

