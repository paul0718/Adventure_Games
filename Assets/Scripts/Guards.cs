using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Guards : MonoBehaviour
{

    NavMeshAgent Guard_NavMeshAgent;
    GameObject player;


    void Start()
    {
        Guard_NavMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(LookForPlayer());
    }

    IEnumerator LookForPlayer(){
        while(true){
            yield return new WaitForSeconds(0.5f);
            Guard_NavMeshAgent.destination = player.transform.position;
        }
    }


    private void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Bullet")){
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
