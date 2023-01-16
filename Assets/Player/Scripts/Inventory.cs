using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Action<Item> onAddItem;
    public List<Item> inventoryItems = new List<Item>();
    public int maxItems = 5;
    public static float cash = 0;

    public void AddItem(Item item)
    {
        if(CountCheck())
            inventoryItems.Add(item);
        onAddItem?.Invoke(item);
    }

    public bool CountCheck()
    {
        if (inventoryItems.Count < maxItems)
            return true;
        else return false;
    }

    public int Count()
    {
        return inventoryItems.Count;
    }

    public void RemoveItem(Item item)
    {
        inventoryItems.Remove(item);
        onAddItem?.Invoke(item);
    }
}