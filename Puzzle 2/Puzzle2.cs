using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public GameObject brokenWires;
    public GameObject fixedWires;
    public GameObject[] bWires;
    public GameObject[] bPillars;
    public GameObject[] items;
    public GameObject altConnections;
    public GameObject Ilight;
    public bool[] pStates = {false, false, false, false, false, false};
    public bool[] wStates = { false, false, false, false, false, false };
    public int ci = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void wireSwitch()
    {
        brokenWires.SetActive(!brokenWires.activeSelf);
        fixedWires.SetActive(!fixedWires.activeSelf);
        Ilight.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
    public void resetLevel(PlayerMovement player)
    {
        for (int i = 0; i < pStates.Length; i++)
        {
            pStates[i] = false;
        }
        for (int i = 0; i < wStates.Length; i++)
        {
            wStates[i] = false;
        }
        foreach (GameObject item in items)
        {
            item.SetActive(true);
            player.hammerUnlock = false;
            player.currentItem.GetComponent<TextMeshProUGUI>().text = "";
        }
    }
    
}
