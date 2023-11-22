using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public void Kill(){
        Destroy(gameObject);
    }
}
