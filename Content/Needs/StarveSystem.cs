using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Content.Needs;

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
