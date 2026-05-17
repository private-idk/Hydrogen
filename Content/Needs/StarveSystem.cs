using System.Collections.Generic;
using Hydrogen.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UtfUnknown.Core.Models.SingleByte.Italian;

namespace Hydrogen.Content.Needs;

public class StarveSystem : GlobalItem
{
    // https://terraria.wiki.gg/wiki/Food
    private static Dictionary<int, int> _saturation = new()
    {
        { ItemID.Marshmallow, 1 },
        { ItemID.Apple, 3 },
        { ItemID.Apricot, 3 },
        { ItemID.Banana, 3 },
        { ItemID.BlackCurrant, -2 },
        { ItemID.BloodOrange, -2 },
        { ItemID.Cherry, 3 },
        { ItemID.Coconut, 5 },
        { ItemID.Elderberry, -2 },
        { ItemID.Grapefruit, 3 },
        { ItemID.Lemon, 1 },
        { ItemID.Mango, 2 },
        { ItemID.Peach, 2 },
        { ItemID.Pineapple, 5 },
        { ItemID.Plum, 1 },
        { ItemID.Pomegranate, -2 },
        { ItemID.Rambutan, -2 },
        { ItemID.Dragonfruit, 5 },
        { ItemID.Starfruit, 5 },
        { ItemID.ChristmasPudding, 10 },
        { ItemID.CookedFish, 10 },
        { ItemID.GingerBeard, 3 },
        { ItemID.SugarCookie, 1 },
        { ItemID.PumpkinPie, 10 },
        { ItemID.FroggleBunwich, 10 },
        { ItemID.BunnyStew, 10 },
        { ItemID.CookedMarshmallow, 2 },
        { ItemID.RoastedBird, 10 },
        { ItemID.SauteedFrogLegs, 10 },
        { ItemID.ShuckedOyster, 5 },
        { ItemID.BowlofSoup, 10 },
        { ItemID.MonsterLasagna, -5 },
        { ItemID.PadThai, 10 },
        { ItemID.Sashimi, 5 },
        { ItemID.BananaSplit, 5 },
        { ItemID.CookedShrimp, 5 },
        { ItemID.Escargot, 5 },
        { ItemID.Fries, 3 },
        { ItemID.LobsterTail, 10 },
        { ItemID.Pho, 10 },
        { ItemID.RoastedDuck, 10 },
        { ItemID.Burger, 5 },
        { ItemID.Pizza, 5 },
        { ItemID.Spaghetti, 10 },
        { ItemID.ChickenNugget, 5 },
        { ItemID.FriedEgg, 5 },
        { ItemID.GrubSoup, 10 },
        { ItemID.SeafoodDinner, 15 },
        { ItemID.Grapes, 1 },
        { ItemID.Hotdog, 5 },
        { ItemID.Nachos, 3 },
        { ItemID.FruitSalad, 5 },
        { ItemID.PotatoChips, 3 },
        { ItemID.ShrimpPoBoy, 5 },
        { ItemID.ChocolateChipCookie, 2 },
        { ItemID.ApplePie, 10 },
        { ItemID.Steak, 10 },
        { ItemID.BBQRibs, 10 },
        { ItemID.Bacon, 5 },
        { ItemID.GoldenDelight, 50 },
    };

    public override bool ConsumeItem(Item item, Player player)
    {
        if (!_saturation.TryGetValue(item.type, out var sat))
            return true;

        if (player.HasBuff(ModContent.BuffType<NotHungryDebuff>()))
            return true;

        HydrogenPlayer.Starve += sat;

        if (sat > 0)
            player.AddBuff(ModContent.BuffType<NotHungryDebuff>(), sat * 3600);

        return true;
    }
}
