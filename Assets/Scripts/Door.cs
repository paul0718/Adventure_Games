using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //public string lvlToLd;
    //public bool locked;
    //public int doorNum;
    public int total_keys;

    void Start()
    {
        //doorNum = gameObject.name[4]; // DoorX, X is the number of the door
    }

    private void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Player")){
            if (ShouldOpen()){
                //the door should only open, not get destroyed
                Destroy(gameObject);
                //SceneManager.LoadScene(lvlToLd)
            }
        }
        // if (other.gameObject.CompareTag("Guard")){
        //     //the door should only open, not get destroyed
        //     //Destroy(gameObject);
        // }
        
    }

    private bool ShouldOpen(){
        //print("Should Open running");
        for(int i = 0; i < PublicVars.total_keys; i++){
            if (PublicVars.Keys[i] == false){
                return false;
            }
        }
        return true;
    }

}
