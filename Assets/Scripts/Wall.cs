using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Renderer _renderer = GetComponent<Renderer>();
        Color oldColor = _renderer.material.color;
        Color newColor = oldColor;
        newColor.a = 0.3f;
        if (player.transform.position.z > transform.position.z)
        {
            _renderer.material.color = newColor;
        }
        else
        {
            _renderer.material.color = oldColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
