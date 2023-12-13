using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System;
public class triggerGarden : MonoBehaviour
{
    public GameObject Panel;
    public int stranichka = 1;
    int list = 1;
    bool firsttime = false;
    [SerializeField] Text TextMP;
    private void Start()
    {
        Panel.SetActive(false);
    }
    public void Click()
    {
        if (stranichka > list)
        {
            TextMP.text = "";
            list++;
            StreamReader sr = new StreamReader(@"C:\Users\79333\Documents\GitHub\theMysteriousShop\Assets\Menu\Help\TextForGame\garden" + list + ".txt");
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                TextMP.text += line + Environment.NewLine;

            }
        }
        else
        {
            Player_Move.minusWindow();
            Panel.SetActive(false);
            list = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        TextMP.text = "";
        if (other.transform.tag == "Player" && firsttime == false)
        {
            StreamReader sr = new StreamReader(@"C:\Users\79333\Documents\GitHub\theMysteriousShop\Assets\Menu\Help\TextForGame\garden" + list + ".txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                TextMP.text += line + Environment.NewLine;

            }
            Player_Move.plusWindow();
            Panel.SetActive(true);
            firsttime = true;
        }
    }
}
