using System.Collections.Generic;
using UnityEngine;

public class Kotel : MonoBehaviour
{
    List<Item> items = new List<Item>();
    [SerializeField] Inventory inv;
    [SerializeField] TextMesh press;
    [SerializeField] Transform spoonRot;
    [SerializeField] Transform spoon;
    [SerializeField] Transform soupTrans;
    Material soup;
    [SerializeField] GameObject kotelGUI;

    public bool use = false;
    public bool empty = true;

    private void Awake()
    {
        soup = soupTrans.GetComponent<Material>();
    }

    private void Update()
    {
        //Вывод по умолчанию
        press.gameObject.SetActive(false);
        press.text = "Press E";

        if (use)
        {
            spoonRot.Rotate(0, Random.Range(1,4), 0);
            spoon.Rotate(0, 0, Random.Range(-1, 1));
            soupTrans.Rotate(0, 0, Random.Range(1, 2));
        }
    }

    public void UseKotel(Camera cam, Transform player)
    {
        cam.transform.position = transform.position + new Vector3(0, 3.5f, 0);
        cam.transform.rotation = Quaternion.Euler(new Vector3 (90,0,0) + player.rotation.eulerAngles);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        use = true;
        kotelGUI.SetActive(true);
    }

    public void EscapeKotel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        kotelGUI.SetActive(false);
        use = false;
    }

    public void KotelInfo(Transform player)
    {
        press.gameObject.SetActive(true);
        press.transform.rotation = player.rotation;
        press.text = "Press E";
    }
}
