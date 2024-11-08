using GLTF.Schema;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    [SerializeField] private GameObject itemContainer;
    [SerializeField] private Animator animator;
    [SerializeField] private float damage;
    [SerializeField] private GameObject player;
    [SerializeField] private BoxCollider boxCollider;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) {
                if (collider.TryGetComponent(out NPCInteractible npcInteractible)) {
                    npcInteractible.Interact();
                    itemContainer.SetActive(true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            animator.SetTrigger("attack");
        } else {
            animator.SetBool("idle", true);
        }
    }

    public NPCInteractible GetInteractibleObject() {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            if (collider.TryGetComponent(out NPCInteractible npcInteractible)) {
                return npcInteractible;
            }
        }
        return null;
    }
}