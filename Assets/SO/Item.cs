using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemsDB", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public GameObject icon;
}
