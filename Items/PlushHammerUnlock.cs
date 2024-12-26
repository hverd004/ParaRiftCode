using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlushHammerUnlock : MonoBehaviour
{
    public PlayerMovement playermove;
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
            playermove.plushHammerUnlock = true;
            playermove.currentItem.GetComponent<TextMeshProUGUI>().text = "Plush Hammer";
            if (erase)
            {
                Destroy(gameObject);
            }
            else
            {
                this.gameObject.SetActive(false);
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
