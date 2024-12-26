using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class FinalPedestal : MonoBehaviour
{
    public bool active;
    public GameObject player;
    public string cObject;
    public GameObject indication;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void place()
    {
        if (player.GetComponent<PlayerMovement>().currentItem.GetComponent<TextMeshProUGUI>().text == "Plush Device" && !active)
        {
            Debug.Log("W");
            active = true;
            player.GetComponent<PlayerMovement>().plushCUnlock = false;
            player.GetComponent<PlayerMovement>().currentItem.GetComponent<TextMeshProUGUI>().text = "";
            this.transform.GetChild(7).gameObject.SetActive(true);
            cObject = "Plush Device";
        }
        else if (!active && player.GetComponent<PlayerMovement>().contraption)
        {
            Debug.Log("WHA");
            active = true;
            this.transform.GetChild(8).gameObject.SetActive(true);
            player.GetComponent<PlayerMovement>().contraption = false;
            player.GetComponent<PlayerMovement>().currentItem.GetComponent<TextMeshProUGUI>().text = "";
            indication.SetActive(false);
            cObject = "Device";
        }
    }
}
