using System;
using Hydrogen.Content.Debuffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen;

public class HydrogenPlayer : ModPlayer
{
    public static int oldBreath;
    public static bool isDrowning;

    public override void PreUpdate()
    {
        oldBreath = Player.breath;
    }
    public override void PostUpdate()
    {
        if (oldBreath > Player.breath && Player.breath > 0)
        {
            Player.breath -= 3;
            isDrowning = true;
        }
        else
        {
            isDrowning = false;
        }

        if (Player.breath == 0)
        {
            Player.AddBuff(BuffID.Confused, 2);
        }

        if (oldBreath == 0 && Player.breath > 0)
        {
            Player.AddBuff(ModContent.BuffType<DrowConsequencesDebuff>(), 30000);
        }
    }
}
