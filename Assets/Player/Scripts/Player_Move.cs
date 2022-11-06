using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody Player;
    public Camera cam;
    public float speed;
    public float runSpeed;
    public float rotateSpeed;
    public float animSpeed;
    [SerializeField] Vector3 camPos;

    Animator anim;
    float animTimer;

    float keyHor;
    float keyVert;
    public static Vector3 dir;

    
    void Start()
    {
        Player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
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

        cam.transform.position = Player.position + camPos;
    }

    void animSwitch(float n)
    {
        animTimer = Mathf.Lerp(animTimer, n, Time.deltaTime * animSpeed);
        anim.SetFloat("walk", animTimer);
    }
}
