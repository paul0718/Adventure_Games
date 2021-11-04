using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void OnTriggerEnter(Collider other){
        //print(other.gameObject.name);
        if (other.gameObject.CompareTag("Key")){
            //print("touched");
            int keynum = (int)char.GetNumericValue(other.gameObject.name[3]); //suppose the name is "KeyX", where X is the number
            Destroy(other.gameObject);
            //print(keynum);
            PublicVars.Keys[keynum] = true;
        }
        else if (other.gameObject.CompareTag("Trap")){
            //LoadScene"Wasted"
        }
        else if (other.gameObject.CompareTag("Guard")){
            //Restart() or TakeDamage()
            //Guards.Stun(2f)
        }
    }
}
