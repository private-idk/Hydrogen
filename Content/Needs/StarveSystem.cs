using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Content.Needs;

public class StarveSystem : GlobalItem
{
    // https://terraria.wiki.gg/wiki/Food
    // private Dictionary<int, int> _saturation = new()
    // {
    //     { ItemID.Apple, 3 }
    // };

    public override bool? UseItem(Item item, Player player)
    {
        if (item.useStyle != ItemUseStyleID.EatFood)
            return null;

        HydrogenPlayer.Starve += 10;

        return null;
    }
}
