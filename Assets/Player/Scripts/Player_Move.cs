using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public float rotateSpeed;
    public Transform Player;
    public Camera cam;

    Animator anim;

    float keyHor;
    float keyVert;
    Vector3 playerRotate;
    Vector3 dir;
    void Start()
    {
        anim = Player.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        keyHor = Input.GetAxis("Horizontal");
        keyVert = Input.GetAxis("Vertical");
        dir = new Vector3(keyHor, 0, keyVert).normalized;

        playerRotate = dir.normalized;
        if(/*Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)*/dir != new Vector3(0,0,0))
        {
            if (playerRotate != new Vector3(0, 0, 0))
            {
                if (dir.x * dir.x > .5f || dir.z * dir.z > .5f)
                    Player.LookAt(Player.position + playerRotate);
                if (Input.GetAxis("Run") != 0)
                {
                    Player.Translate(Vector3.forward * runSpeed * Time.deltaTime);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isStanding", false);
                }
                else
                {
                    Player.Translate(Vector3.forward * speed * Time.deltaTime);
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isStanding", false);
                }
            }
            
            
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isStanding", true);
        }
        
        Debug.Log(transform.position + " " + Player.position);
        transform.position = Player.position;
    }
}
