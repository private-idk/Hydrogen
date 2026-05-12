using System;
using Terraria.Localization;

namespace Hydrogen.API.Stats;

public class ForgingStat : StatBase
{
    public override int Id => 0;

    public override string Name => Language.GetTextValue("Mods.Hydrogen.Stats.Forging");

    public override int Level {get;set;} = 1;
}
