using UnityEngine;

public class Interactive : MonoBehaviour
{
    RaycastHit hit;
    Inventory inv;
    public Item itemToAdd;

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
                    inv.AddItem(itemToAdd);
                }
            }
        } 
    }
}
