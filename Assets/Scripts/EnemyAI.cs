using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour {

    public NavMeshAgent enemy;
    public List<Transform> destinations;
    public Animator enemyAnimator;
    public Transform player;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float chaseSpeed;

    [SerializeField] private float destionationAmount;

    [SerializeField] private float minIdleTime;
    [SerializeField] private float maxIdleTime;
    [SerializeField] private float idleTime;

    [SerializeField] private float minChaseTime;
    [SerializeField] private float maxChaseTime;
    [SerializeField] private float chaseTime;

    [SerializeField] private float searchDistance;
    [SerializeField] private float minSearchTime;
    [SerializeField] private float maxSearchTime;
    [SerializeField] private float detectionDistance;

    [SerializeField] private float sightDistance;
    [SerializeField] private float damageDistance;

    [SerializeField] private float health;
    [SerializeField] private float damage;

    private bool IsWalking;
    private bool IsChasing;
    private bool IsSearching;

    private Transform currentDestination;
    private Vector3 dest;
    public Vector3 rayCastOffset;
    public string deathScene;
    public float aiDistance;

    void Start() {

        IsWalking = true;

        currentDestination = destinations[Random.Range(0, destinations.Count)];
    }
    void Update() {

        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;

        aiDistance = Vector3.Distance(player.position, this.transform.position);

        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, detectionDistance)) {
            if (hit.collider.gameObject.tag == "Player") {
                
                IsWalking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("searchRoutine");
                StartCoroutine("searchRoutine");

                IsSearching = true;
            }
        }
        if (IsSearching == true) {
            
            enemy.speed = 0;

            enemyAnimator.ResetTrigger("walk");
            enemyAnimator.ResetTrigger("idle");
            enemyAnimator.ResetTrigger("sprint");
            enemyAnimator.SetTrigger("search");

            if (aiDistance <= searchDistance) {

                StopCoroutine("stayIdle");
                StopCoroutine("searchRoutine");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");

                IsChasing = true;
                IsSearching = false;
            }
        }
        if (IsChasing == true) {

            dest = player.position;
            enemy.destination = dest;
            enemy.speed = chaseSpeed;

            enemyAnimator.ResetTrigger("walk");
            enemyAnimator.ResetTrigger("idle");
            enemyAnimator.ResetTrigger("search");
            enemyAnimator.SetTrigger("sprint");

            if (aiDistance <= damageDistance) {

                // It will damage the player
                //player.gameObject.SetActive(false);

                enemyAnimator.ResetTrigger("walk");
                enemyAnimator.ResetTrigger("idle");
                enemyAnimator.ResetTrigger("search");
                enemyAnimator.SetTrigger("sprint");

                // Start attack animation and stop the sprint animation
                // enemyAnimator.SetTrigger("atackAnimation"); 
                //

                //StartCoroutine(deathRoutine());

                IsChasing = false;
            }
        }
        if (IsWalking == true) {

            dest = currentDestination.position;
            enemy.destination = dest;
            enemy.speed = walkSpeed;

            enemyAnimator.ResetTrigger("sprint");
            enemyAnimator.ResetTrigger("idle");
            enemyAnimator.ResetTrigger("search");
            enemyAnimator.SetTrigger("walk");

            if (enemy.remainingDistance <= enemy.stoppingDistance) {

                enemyAnimator.ResetTrigger("sprint");
                enemyAnimator.ResetTrigger("walk");
                enemyAnimator.ResetTrigger("search");
                enemyAnimator.SetTrigger("idle");

                enemy.speed = 0;

                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");

                IsWalking = false;
            }
        }
    }
    public void stopChase() {

        IsWalking = true;
        IsChasing = false;

        StopCoroutine("chaseRoutine");

        currentDestination = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator stayIdle() {

        idleTime = Random.Range(minIdleTime, maxIdleTime);

        yield return new WaitForSeconds(idleTime);

        IsWalking = true;

        currentDestination = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator searchRoutine() {

        yield return new WaitForSeconds(Random.Range(minSearchTime, maxSearchTime));

        IsSearching = false;
        IsWalking = true;

        currentDestination = destinations[Random.Range(0, destinations.Count)];
    }
    IEnumerator chaseRoutine() {

        yield return new WaitForSeconds(Random.Range(minChaseTime, maxChaseTime));

        stopChase();
    }
    /*IEnumerator deathRoutine() {

        yield return new WaitForSeconds(jumpscareTime);

        SceneManager.LoadScene(deathScene);
    }*/
}