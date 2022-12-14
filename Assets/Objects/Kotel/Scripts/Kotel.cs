using System.Collections.Generic;
using UnityEngine;

public class Kotel : MonoBehaviour
{
    List<Item> itemUsed = new List<Item>();
    [SerializeField] Inventory inv;
    [SerializeField] TextMesh press;
    public bool use = false;
    public Vector3 correctCamPos;

    private void Update()
    {
        //Вывод по умолчанию
        press.gameObject.SetActive(false);
        press.text = "Press E";

        if (use)
        {

        }
    }

    public void UseKotel(Camera cam, Transform player)
    {
        cam.transform.position = transform.position/* + correctCamPos*/;
        cam.transform.rotation = Quaternion.Euler(new Vector3 (90,0,0) + player.rotation.eulerAngles);

        use = true;
    }

    public void EscapeKotel()
    {
        use = false;
    }

    public void KotelInfo(Transform player)
    {
        press.gameObject.SetActive(true);
        press.transform.rotation = player.rotation;
        press.text = "Press E";
    }
}
