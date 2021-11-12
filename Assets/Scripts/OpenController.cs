using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenController : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    // [SerializeField] private bool openTrigger = false;
    
    
    void Start()
    {
        PublicVars.total_keys = GameObject.FindGameObjectsWithTag("Key").Length;
        PublicVars.Keys = new bool[PublicVars.total_keys];
        // Debug.Log(PublicVars.total_keys);
    }
    
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            if (ShouldOpen()){
                //the door opens
                door.Play("DoorOpen",0,0f);
                gameObject.SetActive(false);
                //SceneManager.LoadScene(lvlToLd)
            }
        }
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
