using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody Player;
    public Transform cam;
    public float speed;
    public float runSpeed;
    public float rotateSpeed;
    public float animSpeed;
    public float camSpeed;
    [SerializeField] Vector3 camPos;

    Animator anim;
    float animTimer;
    float X;
    float Y;
    float Yangle;

    float keyHor;
    float keyVert;
    public static Vector3 dir;
    Vector3 orient;

    
    void Start()
    {
        Player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        keyHor = Input.GetAxis("Horizontal");
        keyVert = Input.GetAxis("Vertical");
        dir = new Vector3(keyHor, 0, keyVert).normalized;

        X = Mathf.Lerp(X, Input.GetAxis("Mouse X"), Time.deltaTime * 10);
        Y = Mathf.Lerp(Y, Input.GetAxis("Mouse Y"), Time.deltaTime * 3);


        Player.transform.Rotate(X * Vector3.up * rotateSpeed);
        if (dir.magnitude >= 0.1)
        {
            if (Input.GetButton("Run"))
            {
                Player.velocity = dir.z * transform.forward * runSpeed + dir.x * transform.right * runSpeed * 0.5f;
                animTimer = Mathf.Lerp(animTimer, 2.0f, Time.deltaTime * animSpeed);
            }
            else
            {
                Player.velocity = dir.z * transform.forward * speed + dir.x * transform.right * runSpeed * 0.5f;
                animTimer = Mathf.Lerp(animTimer, 1.0f, Time.deltaTime * animSpeed);
            }

        } else
            animTimer = Mathf.Lerp(animTimer, 0, Time.deltaTime * animSpeed);
        
        anim.SetFloat("walk", animTimer);

        cam.position = Vector3.Lerp(cam.position, Player.position + camPos, camSpeed * Time.deltaTime);

        
        Yangle -= Y;
        if (Yangle < -4)
        {
            Yangle = -4;
            Y = 0;
        }
        else if (Yangle > 6)
        {
            Y = 0;
            Yangle = 6;
        }
        
        
        cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.LookRotation(transform.forward), 10 * Time.deltaTime);
        cam.rotation *= Quaternion.Euler(Mathf.Clamp( Yangle,-4, 6) , 0, 0);
    }
}
