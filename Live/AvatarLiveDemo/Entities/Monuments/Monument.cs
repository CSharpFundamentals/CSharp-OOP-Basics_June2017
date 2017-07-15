public abstract class Monument
{
    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public abstract double GetMonumentBonus();

    public override string ToString()
    {
        var name = this.GetType().Name;
        var index = name.IndexOf("Monument");
        name = name.Insert(index, " ");

        return $"###{name}: {this.Name},";
    }
}