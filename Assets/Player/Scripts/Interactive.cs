using UnityEngine;

public class Interactive : MonoBehaviour
{
    RaycastHit hit;
    Inventory inv;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
    }

    void Update()
    {
        if(Physics.SphereCast(transform.position, 1.5f, transform.forward, out hit, 3f))
        {
            if (hit.transform.gameObject.tag == "Yagoda")
            {
                Yagodi target = hit.transform.parent.GetComponent<Yagodi>();
                target.YagodaInfo(transform, inv.CountCheck());
                if (Input.GetButtonDown("Use") & target.YagodCheck() & inv.CountCheck())
                {
                    target.YagodaMinus();
                    inv.AddItem(target.itemToAdd);
                }
            }
            if (hit.transform.gameObject.tag == "Krapiva")
            {
                Krapiva target = hit.transform.parent.GetComponent<Krapiva>();
                target.KrapivaInfo(transform, inv.CountCheck());
                if (Input.GetButtonDown("Use") & target.KrapivCheck() & inv.CountCheck())
                {
                    target.KrapivaMinus();
                    inv.AddItem(target.itemToAdd);
                }
            }
        } 
    }
}
