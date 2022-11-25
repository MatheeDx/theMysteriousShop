using UnityEngine;

public class Interactive : MonoBehaviour
{
    RaycastHit hit;
    Inventory inv;
    [SerializeField] Camera cam;

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
            if (hit.transform.gameObject.tag == "Kotel")
            {
                Kotel target = hit.transform.parent.GetComponent<Kotel>();
                if (Input.GetButtonDown("Use"))
                {
                    if (!target.use)
                    {
                        GetComponent<Player_Move>().enabled = false;
                        target.UseKotel(cam, transform);
                        
                        GetComponent<Animator>().SetFloat("walk", 0);
                    } 
                    else 
                    {
                        target.EscapeKotel();
                        GetComponent<Player_Move>().enabled = true;
                        GetComponent<Player_Move>().ReturnCam();
                    }
                } else if (!target.use)
                    target.KotelInfo(transform);

            }
        } 
    }
}
