using UnityEngine;


public class WeaponSwitching : MonoBehaviour {

    [SerializeField] private int SELECTED_WEAPON;

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
}