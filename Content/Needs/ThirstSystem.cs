using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Content.Needs
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
