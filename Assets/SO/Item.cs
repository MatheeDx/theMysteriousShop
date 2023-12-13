using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemsDB", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public string itemDescription;
    public Sprite icon;
    public float price;
    public Color color;
    public int maximumAmount;
    public GameObject itemPrefab;
}
