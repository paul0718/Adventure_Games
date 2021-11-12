using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PublicVars.Keys[0] == true && PublicVars.Keys[1] == true && PublicVars.Keys[2] == true)
        {
            Destroy(gameObject);
        }
    }
}
