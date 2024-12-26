using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionCheck : MonoBehaviour
{
    public GameObject[] cPillars;
    public GameObject[] wPillars;
    public doorOpenGood doorSensor;
    public PlayerMovement player;
    public GameObject Ilight;
    public bool inRange = false;
    public bool correct = false;
    public bool noSolution;
    public GameObject effect;
    public AudioSource correctSound;
    public AudioSource incorrectSound;
    public Animator cantdo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void check()
    {
        correct = true;
        foreach (GameObject p in cPillars) 
        {
            if (p.activeSelf == false)
            {

                correct = false;
            }
        }
        foreach (GameObject p in wPillars)
        {
            if (p.activeSelf == true)
            {
                correct = false;
            }
        }
    }
    public void opening()
    {
        if (player.keyCardUnlock && (correct || noSolution) && (!player.altState))
        {
            doorSensor.unlocked = !(doorSensor.unlocked);
            if (doorSensor.unlocked)
            {
                Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 1, 0));
                correctSound.Play();
            }
            else
            {
                Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 1));
            }
        }
        else if (player.keyCardUnlock && !(player.altState))
        {
            foreach (GameObject p in cPillars)
            {
                if (p.activeSelf)
                {
                    player.switchRemaining = 0;
                    Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1, 0, 0));
                    effect.GetComponent<ParticleSystem>().Play();
                    incorrectSound.Play();
                }
            }
        }
        else if (player.keyCardUnlock && (player.altState))
        {
            cantdo.Play("Alt World Restrict");
        }
    }
}
