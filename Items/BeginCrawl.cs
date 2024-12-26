using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginCrawl : MonoBehaviour
{
    public PlayerMovement playmove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        print("Hello");
        if (playmove.crawlUnlock)
        {
            playmove.canCrawl = true;
            print("collided and active");
        }
        else
        {
            playmove.canCrawl = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        playmove.canCrawl = false;
    }*/
}
