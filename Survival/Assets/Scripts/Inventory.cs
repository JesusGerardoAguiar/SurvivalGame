using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public bool inventoryEnabled;

    public GameObject inventory;
    public GameObject itemDataBase;
    private Transform[] slot;
    public GameObject slotsHolder;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
        {
            inventory.SetActive(true);

        }
        else {
            inventory.SetActive(false);
        }

       
    }

    private void Start()
    {
        GetAllSlots();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            
             AddItem(other.gameObject);
            
        }

    }

    public void AddItem(GameObject item) {
        if (item.GetComponent<ItemPickup>().craftMaterial == false)
        {
            GameObject rootItem;

            rootItem = item.GetComponent<ItemPickup>().rootItem;

            for (int i = 0; i < slot.Length; i++)
            {
                if (slot[i].GetComponent<Slot>().empty == true && item.GetComponent<ItemPickup>().pickedUp == false)
                {
                    slot[i].GetComponent<Slot>().item = rootItem;
                    item.GetComponent<ItemPickup>().pickedUp = true;
                    Destroy(item);
                }
            }
        }
        else {
            for (int i = 0; i < slot.Length; i++)
            {
                if (slot[i].GetComponent<Slot>().empty == true && item.GetComponent<ItemPickup>().pickedUp == false)
                {
                    slot[i].GetComponent<Slot>().item = item;
                    item.GetComponent<ItemPickup>().pickedUp = true;
                    item.transform.parent = itemDataBase.transform;
                    if (item.GetComponent<ItemPickup>().food == true) {
                        PlayerStats.health = PlayerStats.health + 5;
                        
                    }
                    item.GetComponent<MeshRenderer>().enabled = false;

                    Destroy(item.GetComponent<Rigidbody>());
                    Destroy(item.GetComponent<BoxCollider>());
                    Destroy(item.GetComponent<BoxCollider>());
                }
            }
        }
    }

    public void GetAllSlots() {
        slot = new Transform[20];
        for (int i = 0; i < slot.Length; i++) {
            slot[i] = slotsHolder.transform.GetChild(i);
            
        }
    }
}
