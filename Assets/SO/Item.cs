using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDB", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public Texture icon;
}
