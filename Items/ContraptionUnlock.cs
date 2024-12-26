using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContraptionUnlock : MonoBehaviour
{
    public PlayerMovement playermove;
    public GameObject indication;
    public bool onPedestal;
    public GameObject pedestal = null;
    public bool inRange;
    public bool erase;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pickup()
    {
        playermove.contraption = true;
        indication.SetActive(true);
        if (erase)
        {
            Destroy(gameObject);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        if (onPedestal)
        {
            pedestal.GetComponent<FinalPedestal>().cObject = "";
            pedestal.GetComponent<FinalPedestal>().active = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
