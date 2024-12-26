using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clipboard : MonoBehaviour
{
    public GameObject cb;
    public TextMeshProUGUI clipboardText;
    public TextMeshProUGUI clipboardaltText;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clipboardstart()
    {
        if (!player.inMenu)
        {
            cb.gameObject.SetActive(true);
            if (!player.altState)
            {
                cb.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = clipboardText.text;
            }
            else
            {
                cb.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = clipboardaltText.text;
            }
            player.inMenu = true;
            player.inBoard = true;
            player.Boardin = cb.gameObject;
        }
    }
}
