using UnityEngine;


public class Yagodi : MonoBehaviour
{
    public int currentYagod;
    public float reloadTime = 3;
    [SerializeField] TextMesh press;

    [SerializeField] Transform yagoda1;
    [SerializeField] Transform yagoda2;
    [SerializeField] Transform yagoda3;
    
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
        //Вывод по умолчанию
        press.gameObject.SetActive(false);
        press.text = "Press E";

        if (yagodCount < maxYagod)
            timer += Time.deltaTime;

        if(yagodCount != currentYagod & yagodCount >= 0 & yagodCount <= maxYagod)
        {
            if(currentYagod > yagodCount & yagodCount < maxYagod)
                _YagodaPlus();
            else if (currentYagod < yagodCount & yagodCount > 0)
                _YagodaMinus();
        }

        if(timer >= reloadTime & yagodCount < maxYagod)
        {
            timer = 0;
            _YagodaPlus();
            currentYagod++;
        }
    }

    private void _YagodaMinus()
    {
        yagodCount--;
        if (third) {
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

    private void _YagodaPlus()
    {
        yagodCount++;
        if (!first) {
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

    public void YagodaMinus()
    {
        currentYagod--;
    }
    
    public void YagodaPlus()
    {
        currentYagod++;
    }
    public bool YagodCheck()
    {
        if(currentYagod == 0) 
            return false;
        else return true;
    }

    public void YagodaInfo(Transform player, bool canTake)
    {
        press.gameObject.SetActive(true);
        press.transform.rotation = player.rotation;
        if (canTake)
            press.text = "Press E";
        else
            press.text = "No more\nspace";
    }
}
