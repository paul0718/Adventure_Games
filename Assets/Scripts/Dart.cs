using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    // Destroy the dart after 4 seconds
    void Start()
    {
        Destroy(gameObject,4f);
    }
}
