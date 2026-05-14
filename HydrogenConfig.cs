using System;
using Terraria.ModLoader.Config;

namespace Hydrogen;

public class HydrogenConfig : ModConfig
{
    public static HydrogenConfig Instance {get;private set;}

    public override ConfigScope Mode => ConfigScope.ClientSide;

    public override void OnLoaded()
    {
        Instance = this;
    }
}
