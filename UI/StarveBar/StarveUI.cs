using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.UI.StarveBar;

public class StarveUI : ModSystem
{
    private static Texture2D starveTex;

    private static float starveOffset;

    public override void OnModLoad()
    {
        starveTex = ModContent.Request<Texture2D>($"Terraria/Images/Item_{ItemID.Burger}").Value;

        starveOffset = Main.inventoryScale * 52f * 10f + 150f;
    }

    public override void OnModUnload()
    {
        starveTex = null;
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        var bar = Utils.CenteredRectangle(new Vector2(starveOffset + starveTex.Width * 3.5f, Main.inventoryScale * 78f), new Vector2(starveTex.Width * 5f, starveTex.Height / 2));

        for (int i = 1; i < HydrogenPlayer.maxStarve / 20 + 1; i++)
        {
            Color color = new Color(255, 255, 255);

            if (i * 20 > HydrogenPlayer.Starve)
            {
                if (i * 20 - 20 > HydrogenPlayer.Starve)
                {
                    color.R = 50;
                    color.B = 50;
                    color.G = 50;
                }
                else
                {
                    color.R = (byte)(255 - (i * 20 - HydrogenPlayer.Starve) * 10);
                    color.B = (byte)(255 - (i * 20 - HydrogenPlayer.Starve) * 10);
                    color.G = (byte)(255 - (i * 20 - HydrogenPlayer.Starve) * 10);
                }
            }

            spriteBatch.Draw(starveTex,
                new Vector2(starveOffset + starveTex.Width * i, Main.inventoryScale * 52f),
                new Rectangle(0, 0, starveTex.Width, starveTex.Height / 3),
                color);
            
        }

        Rectangle mouseHitbox = new Rectangle((int)Main.MouseScreen.X, (int)Main.MouseScreen.Y, 8, 8);
        if (mouseHitbox.Intersects(bar))
        {
            Main.instance.MouseText($"{HydrogenPlayer.Starve}/{HydrogenPlayer.maxStarve}");
        }
    }
}
