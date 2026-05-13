namespace Hydrogen.Content.Skills;

public abstract class StatBase
{
    public abstract int Id {get;}

    public abstract string Name {get;}

    public abstract int Level {get;set;}

    public abstract int MaxLevel {get;}

    public void LevelUp()
    {
        if (Level + 1 > MaxLevel)
            return;

        Level += 1;
    }

    public static StatBase[] Stats =
    [
        new ForgingStat()
    ];
}
