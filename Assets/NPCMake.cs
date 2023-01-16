using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMake : MonoBehaviour
{
    [SerializeField] Transform npc1;
    public List<Item> goods;

    private void Update()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("Vedma");
        if (npcs.Length == 0)
            Make();
    }

    public void Make()
    {
        Transform target = Instantiate(npc1);
        target.position = transform.position;
        target.rotation = transform.rotation;
        target.GetComponent<VedmaCore>().whatWant = goods[Random.Range(0, goods.Count-1)];
        target.GetComponent<VedmaCore>().npcController = transform.GetComponent<NPCMake>();
    }
}
