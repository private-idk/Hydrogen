using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Content.Buffs;
public class PlayerSlimedDebuff : ModBuff
{
    private int[] _fireItems = [
        ItemID.Hellstone, ItemID.HellstoneBar, ItemID.HellstoneBrick, ItemID.HellstoneBrickWall, ItemID.LivingFireBlock,
        ItemID.Torch, ItemID.Candle, ItemID.Campfire, ItemID.Fireplace, ItemID.HellfireTreads,
        ItemID.FireWhip, ItemID.HelFire, ItemID.VolcanoLarge, ItemID.VolcanoSmall, ItemID.MoltenFury,
        ItemID.Flamarang,ItemID.Sunfury, ItemID.PhoenixBlaster, ItemID.Flamelash, ItemID.MoltenHamaxe,
        ItemID.MoltenCharm, ItemID.MoltenSkullRose, ItemID.MoltenQuiver, ItemID.MoltenPickaxe, ItemID.SolarFlareAxe,
        ItemID.SolarFlareChainsaw, ItemID.SolarFlareDrill, ItemID.SolarFlareHammer, ItemID.FlowerofFire, ItemID.FireGauntlet,
        ItemID.FireFeather, 
    ];

    // Если поблизости игрока будут эти тайлы, то он загорится
    private int[] _tiles = [
        TileID.Hellstone, TileID.HellstoneBrick, TileID.LivingFire, TileID.Torches, TileID.Candles, TileID.Campfire, TileID.Fireplace
    ];

    public override bool RightClick(int buffIndex) => false;
    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
    }
    public override void Update(Player player, ref int buffIndex)
    {
        foreach (var type in _fireItems)
        {
            if (player.HeldItem.type == type)
            {
                player.AddBuff(BuffID.Burning, 2);
                break;
            }
            for (int i = 3; i < 10; i++)
            {
                if (player.armor[i].type == type)
                {
                    player.AddBuff(BuffID.Burning, 2);
                    break;
                }
            }
        }

        int tileX = (int)(player.position.X / 16f);
        int tileY = (int)(player.position.Y / 16f);

        for (int i = -3; i <= 3; i++)
        {
            for (int j = -3; j <= 3; j++)
            {
                int x = tileX + i;
                int y = tileY + j;

                if (!WorldGen.InWorld(x, y))
                    continue;

                var tile = Framing.GetTileSafely(x, y);

                if (tile.HasTile)
                {
                    foreach (var t in _tiles)
                    {
                        if (t == tile.TileType)
                        {
                            player.AddBuff(BuffID.Burning, 2);
                            break;
                        }
                    }
                }
            }
        }
    }
}