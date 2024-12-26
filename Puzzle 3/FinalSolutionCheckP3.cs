using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSolutionCheckP3 : MonoBehaviour
{
    public GameObject pedestal;
    public doorOpenGood doorSensor;
    public PlayerMovement player;
    public GameObject Ilight;
    public bool correct;
    public GameObject effect;
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
        if (!player.badEnd)
        {
            correct = true;
            if (!(pedestal.GetComponent<FinalPedestal>().cObject == "Plush Device"))
            {
                correct = false;
            }

            if (player.keyCardUnlock && correct && (!player.altState))
            {
                doorSensor.unlocked = !(doorSensor.unlocked);
                if (doorSensor.unlocked)
                {
                    Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 1, 0));
                }
                else
                {
                    Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 1));
                }
            }
            else if (player.keyCardUnlock && !(player.altState))
            {
                player.switchRemaining = 0;
                Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1, 0, 0));
                effect.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
