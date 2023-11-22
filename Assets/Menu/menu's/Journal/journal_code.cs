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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        JournalPanel.SetActive(false);
        menuExit = !menuExit;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
