using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool menuExit;
    public GameObject PausePanel;
    private void Start()
    {
        PausePanel.SetActive(false);
    }
    public void ExitGame()
    {
        Debug.Log("Игра всё");
        Application.Quit();
    }
    public void BackGame()
    {
        PausePanel.SetActive(false);
        menuExit = !menuExit;
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Вроде работает");
            menuExit = !menuExit;

            if (PausePanel == menuExit)
            {
                PausePanel.SetActive(true);
            }
            else
            {
                PausePanel.SetActive(false);
            }
        }
    }
}
