using UnityEngine;
using System.Linq;
using System;

public class Interactive : MonoBehaviour
{
    RaycastHit hit;
    Inventory inv;
    [SerializeField] Camera cam;
    bool kotelUse = false;
    Kotel kotel;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
    }

    void Update()
    {
        if(Physics.SphereCast(transform.position, 1.5f, transform.forward, out hit, 3f))
        {
            if (hit.transform.gameObject.tag == "trash")
            {
                Item1 target = hit.transform.GetComponent<Item1>();
                if (Input.GetButtonDown("Use"))
                {
                    GetComponent<InventoryManager>().AddItem(target.item, target.amount);
                    target.Kill();
                }
            }
            if (hit.transform.gameObject.tag == "Yagoda")
            {
                Yagodi target = hit.transform.parent.GetComponent<Yagodi>();
                target.YagodaInfo(transform, inv.CountCheck());
                if (Input.GetButtonDown("Use") & target.YagodCheck())
                {
                    target.YagodaMinus();
                    GetComponent<InventoryManager>().AddItem(target.itemToAdd, 1);

                }
            }
            if (hit.transform.gameObject.tag == "Krapiva")
            {
                Krapiva target = hit.transform.GetComponent<Krapiva>();
                target.KrapivaInfo(transform, inv.CountCheck());
                if (Input.GetButtonDown("Use") & target.KrapivCheck())
                {
                    target.KrapivaMinus();
                    GetComponent<InventoryManager>().AddItem(target.itemToAdd, 1);
                }
            }
            if (hit.transform.gameObject.tag == "Vedma")
            {
                VedmaCore target = hit.transform.GetComponent<VedmaCore>();
                target.VedmaInfo(transform);
                if (Input.GetButtonDown("Use"))
                {
                    foreach(Item item in inv.inventoryItems)
                    {
                        if(item.id == target.ItemCheck())
                        {
                            target.Award();
                            inv.RemoveItem(item);
                            break;
                        }
                    }
                }
            }
            if (hit.transform.gameObject.tag == "Kotel")
            {
                Kotel target = hit.transform.parent.GetComponent<Kotel>();
                kotel = target;
                if (Input.GetButtonDown("Use") | Input.GetButtonDown("Cancel") & target.use)
                {
                    if (!target.use)
                    {
                        GetComponent<Player_Move>().enabled = false;
                        target.UseKotel(cam, transform);
                        kotelUse = true;
                        
                        GetComponent<Animator>().SetFloat("walk", 0);
                    } 
                    else
                    {
                        kotel = null;
                        target.EscapeKotel();
                        GetComponent<Player_Move>().enabled = true;
                        GetComponent<Player_Move>().ReturnCam();
                        kotelUse = false;
                    }
                } else if (!target.use)
                    target.KotelInfo(transform);
            }
        } 
    }

    public bool KotelUse()
    {
        return kotelUse;
    }

    public void KotelItemAdd(Item item)
    {
        if (kotelUse)
        {

            kotel.AddItem(item);
            inv.RemoveItem(item);
        }      
    }
}
