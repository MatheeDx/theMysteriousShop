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
        Application.Quit();
    }
    public void BackGame()
    {
        PausePanel.SetActive(false);
        menuExit = !menuExit;
        Player_Move.minusWindow();
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuExit = !menuExit;

            if (PausePanel == menuExit)
            {
                PausePanel.SetActive(true);
                Player_Move.plusWindow();
            }
            else
            {
                PausePanel.SetActive(false);
                Player_Move.minusWindow();
            }
        }
    }
}
