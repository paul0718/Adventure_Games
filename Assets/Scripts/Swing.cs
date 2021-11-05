using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{ 

    public bool isSwinging;
    public float rotDir;
    float startTime;
    

    float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (!isSwinging)
        {
            StartCoroutine("DoTheSwing");
        }
    }



    IEnumerator DoTheSwing()
    {
        float timeElapsed = 0;

        isSwinging = true;
        while (timeElapsed < 2f)
        {
            rotDir = Mathf.SmoothStep(-100, 100, timeElapsed / 2f);
            transform.Rotate(Vector3.up * rotDir * Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        timeElapsed = 0;
        while (timeElapsed < 2f)
        {
            rotDir = Mathf.SmoothStep(100, -100, timeElapsed / 2f);
            transform.Rotate(Vector3.up * rotDir * Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        isSwinging = false;
    }
}
