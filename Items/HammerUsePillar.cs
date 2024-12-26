using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HammerUsePillar : MonoBehaviour
{
    public PlayerMovement player;
    public Puzzle2 puzzle2;
    public bool inRange;
    public GameObject pPillar;
    public GameObject pWire;
    private bool checkAP;
    public Animator cantdo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print((other.CompareTag("Player") && player.hammerUnlock && Input.GetKey(KeyCode.Mouse0)));
        if (player.hammerUnlock && Input.GetKeyUp(KeyCode.Mouse0) && inRange)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", pWire.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
            this.gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.SetColor("_Color", pPillar.gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
            if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Normal Hammer" && !(player.altState))
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                foreach (GameObject pillar in puzzle2.bPillars)
                {
                    if (pillar.activeSelf)
                    {
                        checkAP = true;
                    }
                }
                if (checkAP)
                {
                    puzzle2.Ilight.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    puzzle2.Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 1));
                }
                else
                {
                    puzzle2.Ilight.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                }

            }
            else if (player.currentItem.GetComponent<TextMeshProUGUI>().text == "Magic Hammer" && !(player.altState))
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                puzzle2.Ilight.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                puzzle2.Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 1));
            }
            else if((player.currentItem.GetComponent<TextMeshProUGUI>().text == "Normal Hammer" || player.currentItem.GetComponent<TextMeshProUGUI>().text == "Magic Hammer") && player.altState)
            {
                cantdo.Play("Alt World Restrict Hammer");
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
    public void checkPA()
    {
        foreach (GameObject pillar in puzzle2.bPillars)
        {
            puzzle2.pStates[puzzle2.ci] = pillar.activeSelf;
            puzzle2.ci++;
        }
        puzzle2.ci = 0;
    }
}
