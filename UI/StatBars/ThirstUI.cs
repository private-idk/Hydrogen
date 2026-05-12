using System;
using System.IO;
using Hydrogen.UI.StarveBar;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.UI.StatBars;

public class ThirstUI : ModSystem
{
    private static Texture2D thirstTex;

    public override void OnModLoad()
    {
        thirstTex = ModContent.Request<Texture2D>($"Terraria/Images/Item_{ItemID.WaterBucket}").Value;
    }

    public override void OnModUnload()
    {
        thirstTex = null;
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        var bar = Utils.CenteredRectangle(new Vector2(StarveUI.generalXOffset + thirstTex.Width * 3.5f, Main.inventoryScale * 78f), new Vector2(thirstTex.Width * 5f, thirstTex.Height / 2));

        for (int i = 1; i < HydrogenPlayer.maxThirst / 20 + 1; i++)
        {
            Color color = new Color(255, 255, 255);

            if (i * 20 > HydrogenPlayer.Thirst)
            {
                if (i * 20 - 20 > HydrogenPlayer.Thirst)
                {
                    color.R = 50;
                    color.B = 50;
                    color.G = 50;
                }
                else
                {
                    color.R = (byte)(255 - (i * 20 - HydrogenPlayer.Thirst) * 10);
                    color.B = (byte)(255 - (i * 20 - HydrogenPlayer.Thirst) * 10);
                    color.G = (byte)(255 - (i * 20 - HydrogenPlayer.Thirst) * 10);
                }
            }

            spriteBatch.Draw(thirstTex,
                new Vector2(StarveUI.generalXOffset + thirstTex.Width * i, Main.inventoryScale * 26f),
                // new Rectangle(0, 0, thirstTex.Width, thirstTex.Height / 3),
                color);
            
        }

        Rectangle mouseHitbox = new Rectangle((int)Main.MouseScreen.X, (int)Main.MouseScreen.Y, 8, 8);
        if (mouseHitbox.Intersects(bar))
        {
            Main.instance.MouseText($"{HydrogenPlayer.Thirst}/{HydrogenPlayer.maxThirst}");
        }
    }
}
