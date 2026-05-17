using System.Collections.Generic;
using Hydrogen.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Content.Needs
{
    public class ThirstSystem : GlobalItem
    {
        private static Dictionary<int, int> _drinks = new()
        {
            { ItemID.Ale, -5 },
            { ItemID.Sake, -5 },
            { ItemID.BottledWater, 5 }
        };

        public override bool? UseItem(Item item, Player player)
        {
            if (player.HasBuff<NotThirstedDebuff>())
                return null;

            else if (_drinks.TryGetValue(item.type, out var sat))
                HydrogenPlayer.Thirst += sat;

            player.AddBuff(ModContent.BuffType<NotThirstedDebuff>(), 3600 * 5);

            return null;
        }
    }
}
