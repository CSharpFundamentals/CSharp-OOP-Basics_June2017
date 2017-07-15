﻿public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity ) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    private int EarthAffinity  { get; }

    public override double GetMonumentBonus()
    {
        return this.EarthAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Earth Affinity: {this.EarthAffinity}";
    }
}