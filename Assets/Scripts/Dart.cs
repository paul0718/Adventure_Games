using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    // Destroy the dart after 4 seconds
    void Start()
    {
        // Destroy(gameObject,4f);
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Guard") ||
            other.gameObject.CompareTag("Wall")){
                Destroy(gameObject);
        }
    }
}
