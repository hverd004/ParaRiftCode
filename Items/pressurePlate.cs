using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    public bool active;
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
        active = true;
        if (other.transform.CompareTag("carry"))
        {
            other.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .15f, this.transform.position.z);
        }
        if (other.GetComponent<boxCarry>() != null)
        {
            other.GetComponent<boxCarry>().inPlate = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        active = false;
        if (other.GetComponent<boxCarry>() != null)
        {
            other.GetComponent<boxCarry>().inPlate = false;
        }
    }
}
