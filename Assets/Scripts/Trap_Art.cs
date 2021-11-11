using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Art : MonoBehaviour
{ 
    
    //Determine what trap it is
    public string trapType;

    //Swinging the swing trap
    public bool isSwinging;
    public float rotDir;
    
    //Spiking the spike trap
    public bool isSpiking;

    // Shooting the dart trap
    public GameObject dart;
    public bool isDarting;

    // Speed of all traps
    float speed = 2f;
    
    // Sound for traps
    public AudioClip spikeInSnd;
    public AudioClip spikeOutSnd;
    public AudioClip swingSnd;
    public AudioClip dartSnd;
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
        if (trapType == "Dart" && !isDarting)
        {
            StartCoroutine("DoTheDart");
        }
    }

    // Rotates the trap back and forth using SmoothStep
    IEnumerator DoTheSwing()
    {
        GetComponent<AudioSource>().PlayOneShot(swingSnd);
        float timeElapsed = 0;

        isSwinging = true;
        
        while (timeElapsed < speed)
        {
            rotDir = Mathf.SmoothStep(-100, 100, timeElapsed / speed);
            transform.Rotate(Vector3.up * rotDir * Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        GetComponent<AudioSource>().PlayOneShot(swingSnd);
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
        GetComponent<AudioSource>().PlayOneShot(spikeInSnd);

        yield return new WaitForSeconds(speed);
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        GetComponent<AudioSource>().PlayOneShot(spikeOutSnd);
        yield return new WaitForSeconds(speed);
        isSpiking = false;
    }

    IEnumerator DoTheDart()
    {
        isDarting = true;
        GetComponent<AudioSource>().PlayOneShot(dartSnd);
        GameObject projectile = Instantiate(dart, transform.position, dart.transform.rotation) as GameObject;
        projectile.GetComponent<Rigidbody>().AddForce(transform.up*500);
        yield return new WaitForSeconds(speed);
        isDarting = false;
    }
}
