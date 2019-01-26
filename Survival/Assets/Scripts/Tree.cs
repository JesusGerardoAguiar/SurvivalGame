using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    public float treeHealth;
    public float currentHealth;
    public int amountOfItems;
    public GameObject[] itemTable;
    private bool itemsDropped;
   // private GameObject theTree;

    public void Start()
    {
        currentHealth = treeHealth;



    }
    public void Update()
    {
        if (currentHealth <= 0) {
            for (int i = 0; i < amountOfItems; i++) {
                Instantiate(itemTable[i].transform, this.transform.position, Quaternion.identity);
                if (i == (amountOfItems - 1)) {
                    itemsDropped = true;
                }
            }
        }

        if (itemsDropped == true) {
            Destroy(this.gameObject);
        }
    }
}
