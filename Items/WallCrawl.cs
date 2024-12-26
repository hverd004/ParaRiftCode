using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallCrawl : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playermove;
    // Start is called before the first frame update
    void Start()
    {
        playermove.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playermove.crawlUnlock = true;
            if (playermove.correctState)
            {
                playermove.currentItem.GetComponent<TextMeshProUGUI>().text = "Wall Crawling";
            }
            else
            {
                playermove.currentItem.GetComponent<TextMeshProUGUI>().text = "Magnet";
            }
            Destroy(this.gameObject);
        }
    }*/
}
