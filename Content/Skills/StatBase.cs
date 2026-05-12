namespace Hydrogen.Content.Skills;

public abstract class StatBase
{
    public abstract int Id {get;}

    public abstract string Name { get; }

    public abstract int Level {get;set;}

    public static StatBase[] Stats =
    [
        new ForgingStat()
    ];
}
