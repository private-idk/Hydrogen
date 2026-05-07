using System;
using Terraria;
using Terraria.ModLoader;

namespace Hydrogen.Content.Debuffs;

public class DrowConsequencesDebuff : ModBuff
{
    public override bool RightClick(int buffIndex) => false;
    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
    }
    public override void Update(Player player, ref int buffIndex)
    {
        if (HydrogenPlayer.isDrowning)
        {
            player.breath -= 6;
        }

        player.velocity.X /= 1.03f;
    }
}
