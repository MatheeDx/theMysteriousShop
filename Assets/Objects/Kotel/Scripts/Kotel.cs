using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Kotel : MonoBehaviour
{
    public List<Recipe> recipes = new List<Recipe>();
    public List<Item> items = new List<Item>();
    public int liquid;
    public Item res;

    [SerializeField] InventoryManager inv;
    [SerializeField] TextMesh press;
    [SerializeField] Transform spoonRot;
    [SerializeField] Transform spoon;
    [SerializeField] Transform soupTrans;
    Renderer soup;
    [SerializeField] GameObject kotelGUI;

    

    public bool use = false;
    public bool empty = true;

    private void Awake()
    {
        soup = soupTrans.GetComponent<Renderer>();
        res = null;
    }

    private void Update()
    {
        //Вывод по умолчанию
        press.gameObject.SetActive(false);
        press.text = "Press E";

        if (use)
        {
            spoonRot.Rotate(0, UnityEngine.Random.Range(1,4), 0);
            spoon.Rotate(0, 0, UnityEngine.Random.Range(-1, 1));
            soupTrans.Rotate(0, 0, UnityEngine.Random.Range(1, 2));
        }
        
    }

    public void UseKotel(Camera cam, Transform player)
    {
        cam.transform.position = transform.position + new Vector3(0, 3.5f, 0);
        cam.transform.rotation = Quaternion.Euler(new Vector3 (90,0,0) + player.rotation.eulerAngles);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        use = true;
        kotelGUI.SetActive(true);
    }

    public void EscapeKotel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        kotelGUI.SetActive(false);
        use = false;
    }

    public void KotelInfo(Transform player)
    {
        press.gameObject.SetActive(true);
        press.transform.rotation = player.rotation;
        press.text = "Press E";
    }

    public void Clear()
    {
        items.Clear();
        liquid = 0;
        res = null;
    }

    public void Use()
    {
        int[] temp1 = new int[items.Count];
        for(int i = 0; i < temp1.Length; i++)
        {
            temp1[i] = items[i].id;
        }
        Array.Sort(temp1);

        for (int i = 0; i < recipes.Count; i++)
        {
            int[] temp2 = new int[recipes[i].items.Count];
            for (int j = 0; j < temp2.Length; j++)
            {
                temp2[j] = recipes[i].items[j].id;
            }
            Array.Sort(temp2);
            if (Enumerable.SequenceEqual(temp1, temp2))
            {
                res = recipes[i].result;
                soup.material.color = res.color;
            } else if (items.Count > 0)
            {
                soup.material.color = new Color(0.13f, 0.4f, 0, 0.09f);
            }
                
        } 
        items.Clear();
    }

    public void Grab()
    {
        if (res == null)
        {
            Debug.Log("Котел пуст");
            return;
        }
        inv.AddItem(res, 1);
        soup.material.color = Color.blue;
        Clear();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        soup.material.color = item.color;
    }
}
