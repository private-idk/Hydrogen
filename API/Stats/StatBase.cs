using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Hydrogen.API.Stats;

public abstract class StatBase
{
    public abstract int Id {get;}

    public abstract string Name { get; }

    public abstract int Level {get;set;}

    public static List<StatBase> Stats = new()
    {
        new ForgingStat()
    };
}
