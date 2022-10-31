using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Rigidbody Player;
    public Camera cam;
    public float speed;
    public float runSpeed;
    public float rotateSpeed;
    public float animSpeed; 

    Animator anim;
    float animTimer;

    float keyHor;
    float keyVert;
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

        if (dir.magnitude >= 0.2)
        {
            if (Input.GetAxis("Run") != 0)
            {
                Player.velocity = dir * runSpeed;
                animSwitch(2f);
            }
            else
            {
                Player.velocity = dir * speed;
                animSwitch(1.0f);
            }
            Player.rotation = Quaternion.Lerp(Player.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        } else
            animSwitch(0.0f);

        transform.position = Player.position;
    }

    void animSwitch(float n)
    {
        animTimer = Mathf.Lerp(animTimer, n, Time.deltaTime * animSpeed);
        anim.SetFloat("walk", animTimer);
    }
}
