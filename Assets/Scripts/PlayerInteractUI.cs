using UnityEditor.Search;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour {

    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;

    private void Update() {
        if (playerInteract.GetInteractibleObject() != null) {
            Show();
        } else {
            Hide();
        }
    }
    private void Show() {
        containerGameObject.SetActive(true);
    }

    private void Hide() {
        containerGameObject.SetActive(false);
    }
}