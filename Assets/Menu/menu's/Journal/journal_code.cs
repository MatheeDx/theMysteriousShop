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
        JournalPanel.SetActive(false);
        menuExit = !menuExit;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Журнал открылся");
            menuExit = !menuExit;

            if (JournalPanel == menuExit)
            {
                JournalPanel.SetActive(true);
            }
            else
            {
                JournalPanel.SetActive(false);
            }
        }
    }
}
