using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) {
                if (collider.TryGetComponent(out NPCInteractible npcInteractible)) {
                    npcInteractible.Interact();
                }
            }
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