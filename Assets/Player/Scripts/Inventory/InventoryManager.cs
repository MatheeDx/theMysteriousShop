using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform inventoryPanel;
    public GameObject hat_panel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;

    public GameObject hat;
    private Item1 ActiveItem;
    static public int count = 0;
        private void Awake()
    {
        UIPanel.SetActive(true);
    }
    void Start()
    {
        for(int i = 0; i< inventoryPanel.childCount; i++){
            if(inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null){
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());   
            }
        }
        UIPanel.SetActive(false);

        hat = transform.GetChild(2).gameObject;

    }

    void Update()
    {
        if(hat_panel.GetComponent<InventorySlot>().isEmpty == false){
            hat.SetActive(true);
        }
        else{
            hat.SetActive(false); 
        }
        if(Input.GetKeyDown(KeyCode.I)){
            isOpened = !isOpened;
            if (isOpened){
                Cursor.lockState = CursorLockMode.Confined;
                UIPanel.SetActive(true);
            }else{
                Cursor.lockState = CursorLockMode.Locked;
                UIPanel.SetActive(false);
            }
        }
            if(Input.GetKeyDown(KeyCode.E) & ActiveItem != null){
                AddItem(ActiveItem.item, ActiveItem.amount);
                ActiveItem.Kill();
                ActiveItem = null;
                count++;
            }
    }
    private void OnTriggerEnter(Collider collision){
        if(collision.TryGetComponent(out Item1 item)){
                ActiveItem = item;
        } 
    }
    private void OnTriggerExit(Collider collision){
        if(collision.TryGetComponent(out Item1 item)){
                ActiveItem = null;
        } 
    }
    private void AddItem(ItemScriptableObject _item, int _amount){
        foreach(InventorySlot slot in slots){
            if(slot.item == _item){
                if(slot.amount + _amount <= _item.maximumAmount){
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
            }
        }
        foreach(InventorySlot slot in slots){
            if(slot.isEmpty == true){
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
    }
}