using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class pedestals : MonoBehaviour
{
    public bool active;
    public bool inRange;
    private GameObject player;
    private bool pedestalUse;
    public string cObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (player.GetComponent<PlayerMovement>() != null)
            {
                if (player.GetComponent<PlayerMovement>().currentItem.GetComponent<TextMeshProUGUI>().text == "Plush Hammer" && Input.GetKeyDown(KeyCode.E) && !active && !pedestalUse && !player.GetComponent<PickupView>().carrying)
                {
                    active = true;
                    cObject = "Plush Hammer";
                    player.GetComponent<PlayerMovement>().plushHammerUnlock = false;
                    player.GetComponent<PlayerMovement>().currentItem.GetComponent<TextMeshProUGUI>().text = "";
                    this.transform.GetChild(7).gameObject.SetActive(true);
                }
                else if (player.GetComponent<PlayerMovement>().currentItem.GetComponent<TextMeshProUGUI>().text == "Plush Box" && Input.GetKeyDown(KeyCode.E) && !active && !pedestalUse && !pedestalUse && !player.GetComponent<PickupView>().carrying)
                {
                    active = true;
                    cObject = "Plush Box";
                    player.GetComponent<PlayerMovement>().plushBoxUnlock = false;
                    player.GetComponent<PlayerMovement>().currentItem.GetComponent<TextMeshProUGUI>().text = "";
                    this.transform.GetChild(8).gameObject.SetActive(true);
                }
                else if (!this.transform.GetChild(7).gameObject.activeSelf && !this.transform.GetChild(8).gameObject.activeSelf)
                {
                    active = false;
                    cObject = "";
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            inRange = true;
        }
        if(other.gameObject.name == "Plush Pedestal" && !active)
        {
            active = true;
            cObject = "Plush Pedestal";
            other.GetComponent<Rigidbody>().useGravity = false;
            pedestalUse = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Plush Pedestal" && !active)
        {
            active = true;
            cObject = "Plush Pedestal";
            pedestalUse = true;
        }
        if(other.gameObject.name == "Plush Pedestal" && other.GetComponent<Rigidbody>().useGravity == true)
        {
            other.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
        if (other.gameObject.name == "Plush Pedestal" && !this.transform.GetChild(7).gameObject.activeSelf && !this.transform.GetChild(8).gameObject.activeSelf)
        {
            active = false;
            cObject = "";
            other.GetComponent<Rigidbody>().useGravity = true;
            pedestalUse = false;
        }
    }
}
