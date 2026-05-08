using System;
using System.Collections.Generic;
using Hydrogen.UI.StarveBar;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Hydrogen.UI;

public class UIManagementSystem : ModSystem
{
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        int mouseIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if (mouseIndex != -1)
        {
            layers.Insert(mouseIndex, new LegacyGameInterfaceLayer("Hydrogen: Starve Bar", delegate
            {
                StarveUI.Draw(Main.spriteBatch);
                return true;
            }, InterfaceScaleType.UI));
        }
    }
}
