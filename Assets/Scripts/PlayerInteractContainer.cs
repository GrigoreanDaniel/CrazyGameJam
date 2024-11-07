using UnityEngine;

public class PlayerInteractContainer : MonoBehaviour {

    [SerializeField] private GameObject itemContainer;
    [SerializeField] private PlayerInteract playerInteract;

    private void Awake() {
        itemContainer.SetActive(false);
    }

    private void Update() {
        if (playerInteract.GetInteractibleObject() != null) {
            itemContainer.SetActive(true);
        }
    }
}