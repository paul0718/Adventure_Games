using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Guards : MonoBehaviour
{

    NavMeshAgent Guard_NavMeshAgent;
    GameObject player;
    Player playerScript;

    // health management
    public HealthBar healthBar;
    void Start()
    {   
        // Tracking the player using navmesh
        Guard_NavMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        StartCoroutine(LookForPlayer());
    }

    IEnumerator LookForPlayer(){
        while(true){
            yield return new WaitForSeconds(0.5f);
            Guard_NavMeshAgent.destination = player.transform.position;
        }
    }


    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){

            // Deal damage, update health bar
            playerScript.ChangeHealth(-25);
            playerScript.StartCoroutine("BeInvulnerable");
            healthBar.UpdateHealthBar();

        }
        else if (other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Trap")){
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
