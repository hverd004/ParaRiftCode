using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRoomsPedestal : MonoBehaviour
{
    public GameObject[] Lock;
    public GameObject[] pedestals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pedestals[0].transform.GetChild(7).gameObject.activeSelf && pedestals[1].transform.GetChild(8).gameObject.activeSelf && pedestals[2].transform.GetChild(9).gameObject.activeSelf)
        {
            foreach(GameObject l in Lock)
            {
                l.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject l in Lock)
            {
                l.SetActive(true);
            }
        }
    }
}
