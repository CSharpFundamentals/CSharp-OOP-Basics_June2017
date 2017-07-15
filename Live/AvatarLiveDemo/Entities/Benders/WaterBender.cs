using System;

public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity ) : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity  { get; private set; }

    public override double GetTotalPower()
    {
        return this.WaterClarity * base.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Water Clarity: {this.WaterClarity:f2}";
    }
}
