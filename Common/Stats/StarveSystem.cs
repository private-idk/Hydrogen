using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Common.Stats;

public class StarveSystem : GlobalItem
{
    public override bool? UseItem(Item item, Player player)
    {
        if (item.useStyle != ItemUseStyleID.EatFood)
            return null;

        HydrogenPlayer.Starve += 10;

        return null;
    }
}
