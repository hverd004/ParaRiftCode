using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HammerUseWall : MonoBehaviour
{
    public bool inRange;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hammerUnlock && Input.GetKeyUp(KeyCode.Mouse0) && inRange)
        {
            if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Normal Hammer" && !(player.altState))
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Magic Hammer" && !(player.altState))
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    public void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
}
