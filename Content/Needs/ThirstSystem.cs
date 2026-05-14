using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Content.Needs
{
    public class ThirstSystem : GlobalItem
    {
        // private Dictionary<int, int> _saturation = new()
        // {
        //     { ItemID.BottledWater, 3 }
        // };

        public override bool? UseItem(Item item, Player player)
        {
            if (item.useStyle != ItemUseStyleID.DrinkLiquid)
                return null;

            HydrogenPlayer.Thirst += 10;

            return null;
        }
    }
}
