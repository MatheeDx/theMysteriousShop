using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VedmaCore : MonoBehaviour
{
    bool ground, floor, isMove = false;
    [SerializeField] List<Vector2> movePoints;
    Animator anim;
    public float speed;
    public Item whatWant;
    [SerializeField] Transform task;
    bool taskShow;
    public NPCMake npcController;

    private void Start()
    {
        isMove = true;
        taskShow = false;
        anim = GetComponent<Animator>();
        StartCoroutine(Comein());
    }

    IEnumerator Comein() {
        anim.SetBool("isStanding", false);
        foreach (Vector2 pos in movePoints)
        {
            Vector3 newPos = new Vector3(pos.x, transform.position.y, pos.y);
            transform.LookAt(newPos);
            while (Vector3.Distance(transform.position, newPos) >= 1f)
            {
                transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime); 
                yield return new WaitForEndOfFrame();
            }
        }
        movePoints.Reverse();
        GiveATask();
    }

    IEnumerator Leave()
    {
        anim.SetBool("isStanding", false);
        foreach (Vector2 pos in movePoints)
        {
            Vector3 newPos = new Vector3(pos.x, transform.position.y, pos.y);
            transform.LookAt(newPos);
            while (Vector3.Distance(transform.position, newPos) >= 1f)
            {
                transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
        //npcController.Make();
        Destroy(gameObject);
    }

    public void GiveATask()
    {
        isMove = false;
        task.gameObject.SetActive(false);
        taskShow = true;
        anim.SetBool("isStanding", true);
    }

    public void Award()
    {
        isMove=true;
        taskShow = false;
        task.gameObject.SetActive(false);
        Inventory.cash += whatWant.price;
        Debug.Log(Inventory.cash);
        StartCoroutine(Leave());
    }

    public void VedmaInfo(Transform player)
    {
        if (!taskShow)
            return;
        task.gameObject.SetActive(true);
        task.GetComponent<SpriteRenderer>().sprite = whatWant.icon;
        task.transform.rotation = player.rotation;
    }

    public int ItemCheck()
    {
        return whatWant.id;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
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
        if (!isMove)
        {
            collision.transform.GetComponent<Sounds>().PlaySteps();
            isMove = true;
        }
        else if (isMove)
        {
            collision.transform.GetComponent<Sounds>().StopSteps();
            isMove = false;
        }
    }
}
