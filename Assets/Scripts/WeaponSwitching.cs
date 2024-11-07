using System.Security.Cryptography;
using UnityEngine;


public class WeaponSwitching : MonoBehaviour {

    [SerializeField] private int SELECTED_WEAPON;
    [SerializeField] private NPCInteractible ITEM_NUMBER;

    public void Start() {
        SelectWeapon();
    }

    public void Update() {
        int PREVIOUS_SELECTED_WEAPON = SELECTED_WEAPON;
        if (Input.GetKey(KeyCode.Alpha1)) {
            SELECTED_WEAPON = 0;
        }

        if (Input.GetKey(KeyCode.Alpha2) && transform.childCount >= 2) {
            SELECTED_WEAPON = 1;

        }
        if (Input.GetKey(KeyCode.Alpha3) && transform.childCount >= 3) {
            SELECTED_WEAPON = 2;
        }

        if (PREVIOUS_SELECTED_WEAPON != SELECTED_WEAPON) {
            SelectWeapon();
        }
    }

    public void SelectWeapon() {
        int WEAPON_COUNTER = 0;
        foreach (Transform weapon in transform) {
            if (WEAPON_COUNTER == SELECTED_WEAPON) {
                weapon.gameObject.SetActive(true);
            } else {
                weapon.gameObject.SetActive(false);
            }
            WEAPON_COUNTER++;
        }
    }

    /*[SerializeField] private GameObject[] weapons;
    [SerializeField] private NPCInteractible weaponInteractible;
    [SerializeField] private bool knifeAquired;
    [SerializeField] private bool pistolAquired;

    private void Start() {
        UnequipWeapons();
        knifeAquired = false;
        pistolAquired = false;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            EquipKnife();
        }

        if (Input.GetKey(KeyCode.Alpha2)) {
            EquipHandgun();

        }
        if (Input.GetKey(KeyCode.Alpha3)) {
            EquipMachinegun();
        }
    }

    private void UnequipWeapons() {
        for (int i = 0; i < weapons.Length; i++) {
            weapons[i].SetActive(false);
        }
    }

    private void EquipKnife() {
        UnequipWeapons();
        if (weaponInteractible.Interact() == 1) {
            weapons[0].SetActive(true);
            knifeAquired = true;
        }
    }

    private void EquipHandgun() {
        UnequipWeapons();
        if (knifeAquired == true) {
            weapons[1].SetActive(true);
            pistolAquired = true;
        }
    }
    private void EquipMachinegun() {
        UnequipWeapons();
        if (knifeAquired == true && pistolAquired == true) {
            weapons[2].SetActive(true);
        }
    }*/

    /* public GameObject knife;
     public GameObject pistol;
     public GameObject gun;

     private bool hasKnife = false;
     private bool hasPistol = false;
     private bool hasGun = false;

     void Update() {
         // Enable knife selection only if picked up
         if (hasKnife && Input.GetKeyDown(KeyCode.Alpha1)) {
             SelectWeapon(knife);
         }

         // Enable pistol selection only if picked up
         if (hasPistol && Input.GetKeyDown(KeyCode.Alpha2)) {
             SelectWeapon(pistol);
         }

         // Enable gun selection only if picked up
         if (hasGun && Input.GetKeyDown(KeyCode.Alpha3)) {
             SelectWeapon(gun);
         }
     }

     public void PickUpKnife() {
         hasKnife = true;
         SelectWeapon(knife); // Automatically select when picked up
     }

     public void PickUpPistol() {
         hasPistol = true;
     }

     public void PickUpGun() {
         hasGun = true;
     }

     private void SelectWeapon(GameObject weapon) {
         knife.SetActive(false);
         pistol.SetActive(false);
         gun.SetActive(false);

         weapon.SetActive(true);
     }*/
}