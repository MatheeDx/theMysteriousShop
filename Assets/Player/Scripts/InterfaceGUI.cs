using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InterfaceGUI : MonoBehaviour
{
    List<GameObject> icons = new List<GameObject>();
    [SerializeField] RectTransform gui;
    Inventory inv;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
    }

    private void Start()
    { 
        inv.onAddItem += onAddItem;
        Draw();
    }

    void onAddItem(Item obj) => Draw();

    private void Draw()
    {
        Clear();
        for(int i = 0; i < inv.Count(); i++)
        {
            var icon = new GameObject(name: "Icon");
            icon.AddComponent<Image>();
            icon.GetComponent<Image>().color = inv.inventoryItems[i].icon.color;
            icon.transform.SetParent(gui.transform);
            icon.transform.localPosition = Vector3.zero;
            icon.transform.localRotation = Quaternion.Euler(Vector3.zero);
            icon.transform.localScale = Vector3.one;
            icons.Add(icon);
        }
    }

    void Clear()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            Destroy(icons[i]);
        }
        icons.Clear();
    }
}
