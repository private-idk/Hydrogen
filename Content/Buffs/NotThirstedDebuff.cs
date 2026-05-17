using Terraria;
using Terraria.ModLoader;

namespace Hydrogen.Content.Buffs;

public class NotThirstedDebuff : ModBuff
{
    public override bool RightClick(int buffIndex) => false;
    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
    }
}