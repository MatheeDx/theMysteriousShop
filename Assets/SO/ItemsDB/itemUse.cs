using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemUse : MonoBehaviour
{
    [SerializeField] Item item;
    public void Click()
    {
        transform.parent.parent.parent.GetComponentInChildren<Inventory>().UseItem(item);
    }
}
