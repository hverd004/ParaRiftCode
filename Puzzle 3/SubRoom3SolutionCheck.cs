using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRoom3SolutionCheck : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject[] locks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(p1.transform.GetChild(7) && p2.transform.GetChild(8) && p3.GetComponent<pedestals>().cObject == "Plush Pedestal")
        {
            foreach (GameObject l in locks)
            {
                l.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject l in locks)
            {
                l.gameObject.SetActive(true);
            }
        }
    }
}
