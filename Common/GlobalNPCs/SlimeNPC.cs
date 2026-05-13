using Hydrogen.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Common.GlobalNPCs
{
    public class SlimeNPC : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            if (entity.aiStyle != NPCAIStyleID.Slime)
                return false;
            return true;
        }

        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(ModContent.BuffType<PlayerSlimedDebuff>(), 600);
        }
    }
}
