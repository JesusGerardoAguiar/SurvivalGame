using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour {
    //Variables
    public static double health;
    
    public double maxHealth = 100.0f;
    

    public static double hungerIncrease = 0.2f;
    public bool triggeringTree;
    private GameObject tree;
    private GameObject food;
    public static bool weaponEquipped;
    public bool triggeringAnimal;

    public Slider healthBar;
    //Functions

    void Start()
    {

        
        health = maxHealth;
        healthBar.value = (float) Calculate(health, maxHealth);
    }

    void Update() {
        
        health -= hungerIncrease * Time.deltaTime;
       

       
        healthBar.value =(float) Calculate(health, maxHealth);
        if (health <= 0) {
            dead();
            Application.Quit();
        }
        
        //triggering with a tree and chopping
        if (triggeringTree == true) {
            
            //Attacking the tree
            if (Input.GetMouseButton(0) && weaponEquipped) {
                if (tree) {
                    tree.GetComponent<Tree>().currentHealth -= 25;
                }
                
            }
        }
        //triggering with an animal and killing it
        if (triggeringAnimal == true)
        {

            //Attacking the animal
            if (Input.GetMouseButton(0) && weaponEquipped)
            {
                if (food)
                {
                    food.GetComponent<Food>().currentHealth -= 25;
                }

            }
        }

    }
    
    void dead() {
        print("Player dead");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree") {
            triggeringTree = true;
            tree = other.gameObject;
        }
        if (other.tag == "Animal") {
            triggeringAnimal = true;
            food = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tree")
        {
            triggeringTree = false;
            tree = null;
        }
        if (other.tag == "Animal")
        {
            triggeringAnimal = false;
            food = null;
        }
    }
    double Calculate(double ch, double h) {
        return ch/h;
    }
}
