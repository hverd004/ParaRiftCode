using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRooms : MonoBehaviour
{
    public GameObject Lock;
    public GameObject[] plate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject p in plate)
        {
            if (p.GetComponent<pressurePlate>() != null)
            {
                if (p.GetComponent<pressurePlate>().active)
                {
                    transfer(p);
                    break;
                }
                else
                {
                    Lock.SetActive(true);
                }
            }
        }
    }
    public void transfer(GameObject p)
    {
        if (Lock.gameObject.GetComponent<doorOpenGood>() != null)
        {

            Lock.GetComponent<doorOpenGood>().unlocked = p.GetComponent<pressurePlate>().active;
        }
        else
        {
            Lock.SetActive(false);
        }
    }
}
