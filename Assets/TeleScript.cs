using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TeleScript : MonoBehaviour
{
    [SerializeField] int locId;
    [SerializeField] string hint;
    [SerializeField] int type;

    private void Awake()
    {
        Collider tele = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            if (type == 1)
                SceneManager.LoadScene(locId);
            else
                other.GetComponent<Player_Move>().hintText.text = hint;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<Player_Move>().hintText.text = "";
    }
}
