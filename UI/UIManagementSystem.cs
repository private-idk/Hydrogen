using System;
using System.Collections.Generic;
using Hydrogen.UI.StarveBar;
using Hydrogen.UI.StatBars;
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

            layers.Insert(mouseIndex, new LegacyGameInterfaceLayer("Hydrogen: Thirst Bar", delegate
            {
                ThirstUI.Draw(Main.spriteBatch);
                return true;
            }, InterfaceScaleType.UI));
        }
    }
}
