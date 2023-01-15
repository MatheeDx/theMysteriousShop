using UnityEngine;


public class Krapiva : MonoBehaviour
{
    public int currentKrapiv;
    public float reloadTime = 3;
    [SerializeField] TextMesh press;
    [SerializeField] Animator anim;
    public Item itemToAdd;
    public AudioClip clip;

    int krapivCount;
    int maxKrapiv = 1;
    float timer = 0;

    private void Start()
    {
        currentKrapiv = 0;
        krapivCount = currentKrapiv;
    }

    private void Update()
    {
        //Вывод по умолчанию
        press.gameObject.SetActive(false);
        press.text = "Press E";

        if (krapivCount < maxKrapiv)
            timer += Time.deltaTime;

        if (krapivCount != currentKrapiv & krapivCount >= 0 & krapivCount <= maxKrapiv)
        {
            if (currentKrapiv > krapivCount & krapivCount < maxKrapiv)
                _KrapivaPlus();
            else if (currentKrapiv < krapivCount & krapivCount > 0)
                _KrapivaMinus();
        }


        if (timer >= reloadTime & krapivCount < maxKrapiv)
        {
            timer = 0;
            _KrapivaPlus();
            currentKrapiv++;
        }
    }

    void _KrapivaPlus()
    {
        anim.SetBool("appear", true);
        krapivCount++;
    }

    void _KrapivaMinus()
    {
        anim.SetBool("appear", false);
        krapivCount--;
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    public void KrapivaPlus()
    {
        currentKrapiv++;
    }

    public void KrapivaMinus()
    {
        currentKrapiv--;
    }

    public bool KrapivCheck()
    {
        if (currentKrapiv == 0)
            return false;
        else return true;
    }

    public void KrapivaInfo(Transform player, bool canTake)
    {
        press.gameObject.SetActive(true);
        press.transform.rotation = player.rotation;
        if (canTake)
            press.text = "Press E";
        else
            press.text = "No more\nspace";
    }
}
