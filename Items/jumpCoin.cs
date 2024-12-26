using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class jumpCoin : MonoBehaviour
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playermove.jumpPowered = true;
            if (playermove.altState)
            {
                playermove.currentItem.GetComponent<TextMeshProUGUI>().text = "Jump Boost";
            }
            else
            {
                playermove.currentItem.GetComponent<TextMeshProUGUI>().text = "Coin";
            }
            Destroy(this.gameObject);
        }
    }
}
