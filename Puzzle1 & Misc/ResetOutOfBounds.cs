using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().switchRemaining = 0;
        }
        if (other.CompareTag("carry"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = new Vector3(-0.321f, 1.64f, 2.115f);
        }
    }
}
