using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;

namespace Hydrogen.Common.GlobalItems;

public class ItemsManager
{
    public static List<Item> ItemId {get;private set;} = new();

    public static bool SafelyGetItem(int id, out Item item)
    {
        item = ItemId[id];

        if (item == null)
            return false;

        return true;
    }

    public static void AddItem(Item item)
    {
        ItemId.Add(item);

        item.SetNameOverride($"[{ItemId.Count}] {item.Name}");
    }
}
