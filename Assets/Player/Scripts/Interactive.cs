using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class Interactive : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] Camera cam;
    bool kotelUse = false;
    Kotel kotel;
    [SerializeField] private TMP_Text hint;

    private void Awake()
    {
        //hint = GetComponent<Player_Move>().hintText;
    }

    void Update()
    {
        if(Physics.SphereCast(transform.position, 1.5f, transform.forward, out hit, 3f))
        {
            if (hit.transform.gameObject.tag == "trash")
            {
                GetComponent<Player_Move>().hintText.text = "Подобрать";
                Item1 target = hit.transform.GetComponent<Item1>();
                if (Input.GetButtonDown("Use"))
                {
                    GetComponent<InventoryManager>().AddItem(target.item, target.amount);
                    hint.text = "";
                    target.Kill();
                }
            }
            else if(hit.transform.gameObject.tag == "Yagoda")
            {
                Yagodi target = hit.transform.parent.GetComponent<Yagodi>();
                hint.text = "Собрать";
                if (Input.GetButtonDown("Use") & target.YagodCheck())
                {
                    target.YagodaMinus();
                    GetComponent<InventoryManager>().AddItem(target.itemToAdd, 1);
                    hint.text = "";
                }
            }
            else if(hit.transform.gameObject.tag == "Krapiva")
            {
                Krapiva target = hit.transform.GetComponent<Krapiva>();
                hint.text = "Собрать";
                if (Input.GetButtonDown("Use") & target.KrapivCheck())
                {
                    target.KrapivaMinus();
                    GetComponent<InventoryManager>().AddItem(target.itemToAdd, 1);
                    hint.text = "";
                }
            }
            else if(hit.transform.gameObject.tag == "Kotel")
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
            } else
            {
                hint.text = "";
            }
        }
        else
        {
            hint.text = "";
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
        }      
    }
}
