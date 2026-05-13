using System;
using Terraria.Localization;

namespace Hydrogen.Content.Skills;

public class ForgingStat : StatBase
{
    public override int Id => StatID.Forging;

    public override string Name => Language.GetTextValue("Mods.Hydrogen.Stats.Forging");

    public override int Level {get;set;} = 1;

    public override int MaxLevel => 10;
}
