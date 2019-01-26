using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    //Variables
    public float animalHealth;
    public float currentHealth;
    public int amountOfItems;
    public GameObject[] itemTable;
    private bool itemsDropped;


    //Functions

    private void Start()
    {
        currentHealth = animalHealth;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            for (int i = 0; i < amountOfItems; i++)
            {
                Instantiate(itemTable[i].transform, this.transform.position, Quaternion.identity);
                if (i == (amountOfItems - 1))
                {
                    itemsDropped = true;
                }
            }
        }

        if (itemsDropped == true)
        {
            Destroy(this.gameObject);
        }
    }
}
