using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Signalchange : MonoBehaviour
{
    public Animator signalM;
    public int pnum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pnum == 1)
        {
            signalM.Play("glitching");
            Debug.Log("play");
        }
        else if (pnum == 2)
        {
            signalM.Play("glitchingp2");
            Debug.Log("play");
        }
        else if (pnum == 3)
        {
            signalM.Play("glitchingp3");
            Debug.Log("play");
        }
    }
}
