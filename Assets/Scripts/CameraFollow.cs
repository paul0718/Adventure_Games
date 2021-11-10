using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject toFollow;

    public Vector3 offset;
    void Start()
    {
        offset = transform.position - toFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = toFollow.transform.position + offset;
    }
}
