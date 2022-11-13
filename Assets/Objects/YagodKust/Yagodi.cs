using UnityEngine;
using UnityEngine.UI;


public class Yagodi : MonoBehaviour
{
    public int currentYagod;
    public float reloadTime = 3;
    public TextMesh press;

    public Transform yagoda1;
    public Transform yagoda2;
    public Transform yagoda3;
    
    bool first;
    bool second;
    bool third;

    int yagodCount;
    int maxYagod = 3;
    float timer = 0;

    private void Start()
    {
        currentYagod = 0;
        yagodCount = currentYagod;
    }

    private void Update()
    {
        press.gameObject.active = false;
        press.text = "Press E";
        if (yagodCount < maxYagod)
            timer += Time.deltaTime;

        if(yagodCount != currentYagod & yagodCount >= 0 & yagodCount <= maxYagod)
        {
            if(currentYagod > yagodCount & yagodCount < maxYagod)
            {
                yagodaPlus();
                yagodCount++;
            } 
            else if (currentYagod < yagodCount & yagodCount > 0)
            {
                yagodaMinus();
                yagodCount--;
            }
        }

        if(timer >= reloadTime & yagodCount < maxYagod)
        {
            timer = 0;
            yagodaPlus();
            yagodCount++;
            currentYagod++;
        }
    }

    private void yagodaMinus()
    {
        if (third)
        {
            third = false;
            yagoda3.GetComponent<Animator>().SetBool("appear", false);
        }
        else if (second)
        {
            second = false;
            yagoda2.GetComponent<Animator>().SetBool("appear", false);
        }
        else if (first)
        {
            first = false;
            yagoda1.GetComponent<Animator>().SetBool("appear", false);
        }
    }

    private void yagodaPlus()
    {
        if (!first)
        {
            first = true;
            yagoda1.GetComponent<Animator>().SetBool("appear", true);
        }
        else if (!second) { 
            second = true;
            yagoda2.GetComponent<Animator>().SetBool("appear", true);
        }
        else if (!third) { 
            third = true;
            yagoda3.GetComponent<Animator>().SetBool("appear", true);
        }
            
    }
    public bool YagodCheck()
    {
        if(currentYagod == 0) 
            return false;
        else return true;
    }
}
