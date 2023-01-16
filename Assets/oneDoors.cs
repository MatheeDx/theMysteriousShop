using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneDoors : MonoBehaviour
{
    [SerializeField] Transform door;
    public float rotate;
    bool isOpening = false;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" || other.transform.tag == "Vedma")
        {
            Debug.Log("wwww");
            isOpening = true;
            while(Mathf.Abs( door.transform.rotation.y * Mathf.Rad2Deg - rotate) > 2f && isOpening)
            {
                door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.Euler(0, rotate, 0), Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            //door.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Vedma")
        {
            isOpening = false;
            Debug.Log(door.transform.rotation.y);
            while (Mathf.Abs(door.transform.rotation.y * Mathf.Rad2Deg) > 2f && !isOpening)
            {
                door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            //door.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
