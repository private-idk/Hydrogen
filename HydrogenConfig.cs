using System;
using Terraria.ModLoader.Config;

namespace Hydrogen;

public class HydrogenConfig : ModConfig
{
    public static HydrogenConfig Instance {get;private set;}

    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Range(0, 2560)]
    public int NeedsUIPositionX;

    [Range(0, 1440)]
    public int NeedsUIPositionY;

    [Range(0, 200)]
    public int BarsOffset;

    public override void OnLoaded()
    {
        Instance = this;
    }
}
