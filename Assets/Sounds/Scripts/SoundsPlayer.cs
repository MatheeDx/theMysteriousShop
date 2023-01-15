using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    bool ground, floor, isMove=false;
    private void Start()
    {
        isMove = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Ground" )
        {
            collision.transform.GetComponent<Sounds>().PlaySteps();
            ground = true;
        }
        else if (collision.transform.tag == "Floor")
        {
            Debug.Log("POL");
            collision.transform.GetComponent<Sounds>().PlaySteps();
            floor = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (ground == true && collision.transform.tag == "Ground")
        {
            collision.transform.GetComponent<Sounds>().StopSteps();
            ground = false;
        }
        else if (ground == true && collision.transform.tag == "Floor")
        {
            collision.transform.GetComponent<Sounds>().StopSteps();
            floor = false;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (GetComponent<Player_Move>().isMoving && !isMove)
        {
            collision.transform.GetComponent<Sounds>().PlaySteps();
            isMove = true;
        }
        else if (!GetComponent<Player_Move>().isMoving && isMove)
        {
            collision.transform.GetComponent<Sounds>().StopSteps();
            isMove = false;
        }
    }
}
