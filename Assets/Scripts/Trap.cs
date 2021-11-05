using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{ 
    
    //Determine what trap it is
    public string trapType;
    //Swinging the swingtrap
    public bool isSwinging;
    public float rotDir;
    
    //Spiking the spiketrap
    public bool isSpiking;

    // Speed of all traps
    float speed = 2f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        // If its a swing trap and its not swinging -> swing
        if (trapType == "Swing" && !isSwinging)
        {
            StartCoroutine("DoTheSwing");
        }
        if (trapType == "Spike" && !isSpiking)
        {
            StartCoroutine("DoTheSpike");
        }
    }

    // Rotates the trap back and forth using SmoothStep
    IEnumerator DoTheSwing()
    {
        float timeElapsed = 0;

        isSwinging = true;
        while (timeElapsed < speed)
        {
            rotDir = Mathf.SmoothStep(-100, 100, timeElapsed / speed);
            transform.Rotate(Vector3.up * rotDir * Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        timeElapsed = 0;
        while (timeElapsed < speed)
        {
            rotDir = Mathf.SmoothStep(100, -100, timeElapsed / speed);
            transform.Rotate(Vector3.up * rotDir * Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        isSwinging = false;
    }

    IEnumerator DoTheSpike()
    {
        isSpiking = true;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(speed);
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(speed);
        isSpiking = false;
    }
}
