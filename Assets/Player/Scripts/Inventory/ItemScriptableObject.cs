using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType{Default, Food, instrument}
public class ItemScriptableObject : ScriptableObject
{
    public itemType itemType;
    public string itemName;
    public int maximumAmount;
    public GameObject itemPrefab;
    public Sprite icon;
    public string itemDescription;   
}
