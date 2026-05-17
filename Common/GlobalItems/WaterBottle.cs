using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Common.GlobalItems;

public class WaterBottle : GlobalItem
{
    public override void SetDefaults(Item entity)
    {
        if (entity.type == ItemID.BottledWater)
        {
            entity.healLife = 1;
            entity.potion = false;
        }        
    }

    public override bool ConsumeItem(Item item, Player player)
    {
        if (item.type == ItemID.BottledWater)
        {
            player.QuickSpawnItem(player.GetSource_ItemUse(item), ItemID.Bottle);
            return true;
        }

        return base.ConsumeItem(item, player);
    }
}
