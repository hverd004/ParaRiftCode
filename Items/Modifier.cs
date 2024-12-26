using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void activate()
    {
        if (player.keyCardUnlock && !player.inMenu)
        {
            if (player.altState)
            {
                //switch item state from real
                if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Coin")
                {
                    player.currentItem.GetComponent<TextMeshProUGUI>().text = "Jump Boost";
                }
                else if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Magnet")
                {
                    player.currentItem.GetComponent<TextMeshProUGUI>().text = "Wall Crawling";
                }
                else if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Normal Hammer")
                {
                    player.currentItem.GetComponent<TextMeshProUGUI>().text = "Magic Hammer";
                    player.currentHammer = "Magic Hammer";
                }
            }
            else
            {
                //switch item state to real
                if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Jump Boost")
                {
                    player.currentItem.GetComponent<TextMeshProUGUI>().text = "Coin";
                }
                else if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Wall Crawling")
                {
                    player.currentItem.GetComponent<TextMeshProUGUI>().text = "Magnet";
                }
                else if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Magic Hammer")
                {
                    player.currentItem.GetComponent<TextMeshProUGUI>().text = "Normal Hammer";
                    player.currentHammer = "Normal Hammer";
                }
            }
        }
    }
}
