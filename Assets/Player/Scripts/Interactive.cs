using UnityEngine;

public class Interactive : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Inventory inv;
    public Item itemToAdd;

    private void Awake()
    {
        inv = GetComponent<Inventory>();
    }

    void Update()
    {
        
        if(Physics.SphereCast(transform.position, 3, transform.forward, out hit, 1f))
        {
            Debug.DrawRay(transform.position, transform.forward * 1, Color.yellow);
            Debug.Log("!!!");
            if (hit.transform.gameObject.tag == "Yagoda" & inv.CountCheck())
            {
                hit.transform.parent.GetComponent<Yagodi>().press.gameObject.active = true;
                hit.transform.parent.GetComponent<Yagodi>().press.transform.rotation = transform.rotation;
                if (Input.GetKeyDown(KeyCode.E) & inv.CountCheck() & hit.transform.parent.GetComponent<Yagodi>().YagodCheck())
                {
                    hit.transform.parent.GetComponent<Yagodi>().currentYagod--;
                    inv.AddItem(itemToAdd);
                } 
            }
            else if (hit.transform.gameObject.tag == "Yagoda")
            {
                hit.transform.parent.GetComponent<Yagodi>().press.gameObject.active = true;
                hit.transform.parent.GetComponent<Yagodi>().press.text = "No more\nspace";
                hit.transform.parent.GetComponent<Yagodi>().press.transform.rotation = transform.rotation;
            }
                
        } else
            {
                Debug.DrawRay(transform.position, transform.forward * 1 , Color.red);
            
            }
    }

    
}
