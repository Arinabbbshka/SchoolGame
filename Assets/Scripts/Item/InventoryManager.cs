using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpened;
    public float reachDistance = 3f;
    private Camera mainCamera;
    public static int thingsCount = 0;


    private void Awake()
    {
        UIPanel.SetActive(true);
    }
    private void Start()
    {
       mainCamera = Camera.main;
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIPanel.SetActive(false);
    }
    Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            if (isOpened)
            {
                UIPanel.SetActive(true);
            }
            else
            {
                UIPanel.SetActive(false);
            }
        }
        Ray ray = mainCamera.ScreenPointToRay(Ray_start_position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.GetComponent<item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<item>().itemss, hit.collider.gameObject.GetComponent<item>().amount);
                    Destroy(hit.collider.gameObject);
                    thingsCount++;
                }
            UnityEngine.Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.green);
            }
        }
        else
        {
            UnityEngine.Debug.DrawRay(ray.origin, ray.direction*reachDistance, Color.red);
        }
        
    }
    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach(InventorySlot slot in slots)
        {
            if(slot.item == _item)
            {
                slot.amount += _amount;
                slot.itemAmount.text = slot.amount.ToString();
                
                return;
            }
        }
        foreach(InventorySlot slot in slots)
        {
            if(slot.isEmpty) 
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icons);
                slot.itemAmount.text = slot.amount.ToString(); 
                break;
            }
        }
    }
    
}
