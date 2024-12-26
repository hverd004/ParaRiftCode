using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentingRooms : MonoBehaviour
{
    public GameObject leBox;
    public GameObject kingRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("carry"))
        {
            other.transform.SetParent(this.transform);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
            other.transform.SetSiblingIndex(0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("carry"))
        {
            other.transform.SetParent(kingRoom.transform);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
