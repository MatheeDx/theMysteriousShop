using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>();
    public int maxItems = 5;

    public void AddItem(Item item)
    {
        if(CountCheck())
            inventoryItems.Add(item);
    }

    public bool CountCheck()
    {
        if (inventoryItems.Count < maxItems)
            return true;
        else return false;
    }
}