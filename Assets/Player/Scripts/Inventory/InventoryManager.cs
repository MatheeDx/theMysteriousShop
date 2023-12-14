using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public GameObject KotelGUI;
    public Transform inventoryPanel;
    public Transform instrumInventoryPanel;
    public GameObject hat_panel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public List<InventorySlot> instrumSlots = new List<InventorySlot>();

    public bool isOpened;

    public GameObject hat;
    private Item ActiveItem;
    static public int count = 0;
        private void Awake()
    {
        UIPanel.SetActive(true);
        KotelGUI.SetActive(true);
    }
    void Start()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }


        for (int i = 0; i < instrumInventoryPanel.childCount; i++)
        {
            if (instrumInventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                instrumSlots.Add(instrumInventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }

        UIPanel.SetActive(false);
        KotelGUI.SetActive(false);

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
                //Cursor.lockState = CursorLockMode.Confined;
                Player_Move.plusWindow();
                UIPanel.SetActive(true);
            }else{
                //Cursor.lockState = CursorLockMode.Locked;
                Player_Move.minusWindow();
                UIPanel.SetActive(false);
            }
        }
            /*if(Input.GetKeyDown(KeyCode.E) & ActiveItem != null){
                AddItem(ActiveItem.item, ActiveItem.amount);
                ActiveItem.Kill();
                GetComponent<Player_Move>().hintText.text = "";
                ActiveItem = null;
                count++;
            }*/
    }
    /*private void OnTriggerEnter(Collider collision){
        if(collision.TryGetComponent(out Item item)){
            ActiveItem = item;
            GetComponent<Player_Move>().hintText.text = "� - �������";
        } 
    }
    private void OnTriggerExit(Collider collision){
        if(collision.TryGetComponent(out Item item)){
            ActiveItem = null;
            GetComponent<Player_Move>().hintText.text = "";
        } 
    }*/
    public void AddItem(Item _item, int _amount){
        foreach(InventorySlot slot in slots){
            if(slot.item == _item){
                if(slot.amount + _amount <= _item.maximumAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    break;
                }
                //break;
            }
        }
        foreach (InventorySlot slot in instrumSlots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maximumAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                //break;
            }
        }
        foreach (InventorySlot slot in slots){
            if(slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
        foreach (InventorySlot slot in instrumSlots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
        count++;
    }
}