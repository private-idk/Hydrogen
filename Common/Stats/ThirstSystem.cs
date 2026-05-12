using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Common.Stats
{
    public class ThirstSystem : GlobalItem
    {
        public override bool? UseItem(Item item, Player player)
        {
            if (item.useStyle != ItemUseStyleID.DrinkLiquid)
                return null;

            HydrogenPlayer.Thirst += 10;

            return null;
        }
    }
}
