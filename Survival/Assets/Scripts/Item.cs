using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public Texture itemTexture;
    public bool craftMaterial;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !craftMaterial) {
            this.gameObject.SetActive(false);
            PlayerStats.weaponEquipped = false;
        }
    }
}
