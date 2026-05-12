using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.Common.AllNPC
{
    public class SlimeNPC : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            if (entity.type == NPCID.GreenSlime)
            {
                return true;
            }
            return false;
        }
    }
}
