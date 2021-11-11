using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Guards : MonoBehaviour
{
    NavMeshAgent guard_navMeshAgent;
    GameObject player;
    Player playerScript;

    //States bools
    bool vulnerable = true;
    bool immune = false;
    bool can_move = true;

    // health management
    public HealthBar healthBar;
    void Start()
    {   
        // Tracking the player using navmesh
        guard_navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        StartCoroutine(LookForPlayer());
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            // Deal damage, update health bar
            playerScript.ChangeHealth(-25);
            playerScript.StartCoroutine("BeInvulnerable");
            healthBar.UpdateHealthBar();
        }
        else if (other.CompareTag("Fixed_Trap")){
            Destroy(gameObject);
        }
        else if (other.CompareTag("Poison")){
            StartCoroutine("Poisoned");
        }
        // else if (other.CompareTag("Sleep")){
        //     StartCoroutine("Sleeping");
        // }
    }


    void Update()
    {
        
    }


    IEnumerator LookForPlayer(){
        while(true){
            if (can_move){
                yield return new WaitForSeconds(0.5f);
                guard_navMeshAgent.destination = player.transform.position;
            }
        }
    }

    IEnumerator BeInvulnerable(){
        vulnerable = false;
        yield return new WaitForSeconds(2f);
        vulnerable = true;
    }

    IEnumerator BeImmune(){
        immune = true;
        yield return new WaitForSeconds(3f);
        immune = false;
    }

    IEnumerator Sleeping(){
        if (!immune){
            StartCoroutine("BeImmune");
            guard_navMeshAgent.isStopped = true;
            can_move = false;
            yield return new WaitForSeconds(2f);
            guard_navMeshAgent.isStopped = false;
            can_move = true;
        }
    }

    IEnumerator Poisoned(){
        if (!immune){
            StartCoroutine("BeImmune");
            guard_navMeshAgent.speed *= 0.2f;
            yield return new WaitForSeconds(2f);
            guard_navMeshAgent.speed *= 5f;
        }
    }
}
