using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemUse : MonoBehaviour
{
    [SerializeField] Item item;

    public void Click()
    {
        if (transform.parent.parent.parent.GetComponentInChildren<Interactive>().KotelUse())
        {
            transform.parent.parent.parent.GetComponentInChildren<Interactive>().KotelItemAdd(item);
        }
        else
            transform.parent.parent.parent.GetComponentInChildren<Inventory>().RemoveItem(item);
    }
}