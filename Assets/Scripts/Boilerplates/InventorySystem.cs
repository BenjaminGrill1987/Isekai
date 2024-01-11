using Isekai.Itemsystem;
using Isekai.Utility;
using System.Collections.Generic;


public class InventorySystem : Singleton<InventorySystem>
{
    Dictionary<ItemData, int> _inventory = new Dictionary<ItemData, int>();

    public static void AddItem(ItemData item, int value = 1)
    {
        if (_Instance._inventory.ContainsKey(item))
        {
            _Instance._inventory[item] = _Instance._inventory[item] + value;
        }
        else
        {
            _Instance._inventory.Add(item, value);
        }
    }

    public static void SubtractItem(ItemData item, int value = 1)
    {
        _Instance._inventory[item] = _Instance._inventory[item] - value;

        if (_Instance._inventory[item] <= 0)
        {
            _Instance._inventory.Remove(item);
        }
    }

    public static Dictionary<ItemData, int> GetInventory()
    {
        return _Instance._inventory;
    }

    public static int GetItemAmount(int newID)
    {
        foreach (var item in GetInventory())
        {
            if (item.Key.GetId() == newID) return item.Value;
        }

        return 0;
    }
}
