using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HammerUnlock : MonoBehaviour
{
    public PlayerMovement playermove;
    public bool inRange;
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
            playermove.hammerUnlock = true;
            playermove.currentItem.GetComponent<TextMeshProUGUI>().text = "Normal Hammer";
            this.gameObject.SetActive(false);
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
