using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    // Start is called before the first frame update

    public float life_seconds = 2;
    void Start()
    {
        Destroy(gameObject, life_seconds);
    }


}
