using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class journal_code : MonoBehaviour
{
    public bool menuExit;
    public GameObject JournalPanel;
  
    void Start()
    {
        JournalPanel.SetActive(false);
    }
    public void BackGame()
    {
        Player_Move.minusWindow();
        JournalPanel.SetActive(false);
        menuExit = !menuExit;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Player_Move.plusWindow();
            menuExit = !menuExit;

            if (JournalPanel == menuExit)
            {
                JournalPanel.SetActive(true);
                Player_Move.plusWindow();
            }
            else
            {
                JournalPanel.SetActive(false);
                Player_Move.minusWindow();
            }
        }
    }
}
