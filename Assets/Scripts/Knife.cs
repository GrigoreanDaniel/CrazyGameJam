using UnityEngine;

public class Knife : MonoBehaviour {

    [SerializeField] private Animator animator;
    [SerializeField] private float damage;
    [SerializeField] private BoxCollider knifeCollider;

    private bool canDamage = false;

    private void Start() {
        knifeCollider.enabled = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            animator.SetTrigger("attack");
        }
    }

    public void EnableDamage() {
        canDamage = true;
        knifeCollider.enabled = true;
    }
    public void DisableDamage() {
        canDamage = false;
        knifeCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (canDamage && other.CompareTag("Enemy")) {
            EnemyAI enemy = other.GetComponent<EnemyAI>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
                canDamage = false;
            }
        }
    }
}