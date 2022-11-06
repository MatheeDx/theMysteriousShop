using UnityEngine;

public class Interactive : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        if(Physics.SphereCast(transform.position, 3.0f, Player_Move.dir * 3, out hit))
        {
            Debug.DrawRay(transform.position, Player_Move.dir*3, Color.yellow);
        } else
        {
            Debug.DrawRay(transform.position, Player_Move.dir*3, Color.red);
            
        }
    }

    
}
