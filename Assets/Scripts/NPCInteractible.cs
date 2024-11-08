using UnityEngine;

public class NPCInteractible : MonoBehaviour {

    [SerializeField] private GameObject unpickedItem;
    [SerializeField] private GameObject pickedItem;
    [SerializeField] private PlayerInteract playerInteract;
    //[SerializeField] private GameObject hideItem1;
    //[SerializeField] private GameObject hideItem2;

    /*private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }*/

    public void Interact() {
        if (playerInteract.GetInteractibleObject() != null) {
            Object.Destroy(unpickedItem);
            pickedItem.SetActive(true);
            //hideItem1.SetActive(false);
            //hideItem2.SetActive(false);
        }
    }
}