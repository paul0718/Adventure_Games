using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject toFollow;

    public Vector3 offset;
    void Start()
    {
        offset = new Vector3(0,29.4839249f,-8.97572613f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = toFollow.transform.position + offset;
    }
}
