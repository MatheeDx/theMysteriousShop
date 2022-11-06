using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yagodi : MonoBehaviour
{
    public int currentYagod = 3;
    public Transform yagoda1;
    public Transform yagoda2;
    public Transform yagoda3;
    bool first;
    bool second;
    bool third;

    int yagod;
    int maxYagod = 3;

    private void Start()
    {
        currentYagod = 3;
    }

    private void Update()
    {
        if(yagod != currentYagod)
        {
            if(currentYagod > yagod)
            {
                yagodaPlus();
                yagod++;
            } 
            else if (currentYagod < yagod)
            {
                yagodaMinus();
                yagod--;
            }
        }
    }

    private void yagodaMinus()
    {
        if (third)
        {
            third = false;
        }
        else if (second)
        {
            second = false;
        }
        else if (first)
        {
            first = false;
        }
    }

    private void yagodaPlus()
    {
        if (!first)
        {
            first = true;
        }
        else if (!second) { 
            second = true; 
        }
        else if (!third) { 
            third = true; 
        }
            
    }
}
