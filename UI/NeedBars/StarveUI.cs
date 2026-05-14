using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hydrogen.UI.NeedBars;

public class StarveUI : ModSystem
{
    public static Texture2D starveTex;

    public static float generalXOffset;
    public static float generalYOffset;
    private static Rectangle mouseRectangle;

    public override void OnModLoad()
    {
        starveTex = ModContent.Request<Texture2D>($"Terraria/Images/Item_{ItemID.Apple}").Value;

        generalXOffset = 500f;
        generalYOffset = 100f;

        mouseRectangle = Utils.CenteredRectangle(
            new Vector2(generalXOffset + starveTex.Width * 3.5f, generalYOffset - starveTex.Height / 1.5f),
            new Vector2(starveTex.Width * 5f, starveTex.Height / 3));
    }

    public override void OnModUnload()
    {
        starveTex = null;
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
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
                new Vector2(generalXOffset + starveTex.Width * i, Main.inventoryScale * 52f),
                new Rectangle(0, 0, starveTex.Width, starveTex.Height / 3),
                color);
            
        }

        Rectangle mouseHitbox = new Rectangle((int)Main.MouseScreen.X, (int)Main.MouseScreen.Y, 8, 8);
        if (mouseHitbox.Intersects(mouseRectangle))
        {
            Main.instance.MouseText($"{HydrogenPlayer.Starve}/{HydrogenPlayer.maxStarve}");
        }
    }
}
