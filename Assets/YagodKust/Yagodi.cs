using UnityEngine;


public class Yagodi : MonoBehaviour
{
    public int currentYagod;
    public Transform yagoda1;
    public Transform yagoda2;
    public Transform yagoda3;
    float timer = 0;
    public float reloadTime = 3;
    bool first;
    bool second;
    bool third;

    public int yagod;
    int maxYagod = 3;

    private void Start()
    {
        currentYagod = 0;
        yagod = currentYagod;
    }

    private void Update()
    {
        if(yagod < maxYagod)
            timer += Time.deltaTime;
        if(yagod != currentYagod & yagod >= 0 & yagod <= maxYagod)
        {
            if(currentYagod > yagod & yagod < maxYagod)
            {
                yagodaPlus();
                yagod++;
            } 
            else if (currentYagod < yagod & yagod > 0)
            {
                yagodaMinus();
                yagod--;
            }
        }

        if(timer >= reloadTime & yagod < maxYagod)
        {
            timer = 0;
            yagodaPlus();
            yagod++;
            currentYagod++;
        }
    }

    private void yagodaMinus()
    {
        if (third)
        {
            third = false;
            yagoda3.GetComponent<Animator>().SetBool("disappear", true);
            yagoda3.GetComponent<Animator>().SetBool("appear", false);
        }
        else if (second)
        {
            second = false;
            yagoda2.GetComponent<Animator>().SetBool("disappear", true);
            yagoda2.GetComponent<Animator>().SetBool("appear", false);
        }
        else if (first)
        {
            first = false;
            yagoda1.GetComponent<Animator>().SetBool("disappear", true);
            yagoda1.GetComponent<Animator>().SetBool("appear", false);
        }
    }

    private void yagodaPlus()
    {
        if (!first)
        {
            first = true;
            yagoda1.GetComponent<Animator>().SetBool("disappear", false);
            yagoda1.GetComponent<Animator>().SetBool("appear", true);
        }
        else if (!second) { 
            second = true;
            yagoda2.GetComponent<Animator>().SetBool("disappear", false);
            yagoda2.GetComponent<Animator>().SetBool("appear", true);
        }
        else if (!third) { 
            third = true;
            yagoda3.GetComponent<Animator>().SetBool("disappear", false);
            yagoda3.GetComponent<Animator>().SetBool("appear", true);
        }
            
    }
}
