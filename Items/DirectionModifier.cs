using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DirectionModifier : MonoBehaviour
{
    public GameObject hRooms;
    public GameObject vRooms;
    public GameObject leBox;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator rotate()
    {
        if (!player.GetComponent<PlayerMovement>().inMenu)
        {
            player.GetComponent<PlayerMovement>().swaping = true;
            player.GetComponentInChildren<PlayerLooking>().spinning = true;
            player.GetComponentInChildren<PostProcessVolume>().weight = 1f;
            if (hRooms.transform.rotation.y == 0)
            {
                hRooms.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                hRooms.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (vRooms.transform.rotation.x == 0)
            {
                vRooms.transform.rotation = Quaternion.Euler(180, 0, 0);
            }
            else
            {
                vRooms.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (leBox.transform.position.z > -10.5)
            {
                leBox.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10), ForceMode.Impulse);
            }
            else
            {
                leBox.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);
            }
            for (int i = 0; i < 36; i++)
            {
                player.transform.Rotate(Vector3.up, 5);
                player.transform.Rotate(Vector3.right, 10f);
                yield return new WaitForSeconds(.015f);
            }
            player.transform.localRotation = Quaternion.Euler(0, 0 , 0);
            yield return new WaitForSeconds(.05f);
            player.GetComponent<PlayerMovement>().swaping = false;
            player.GetComponentInChildren<PostProcessVolume>().weight = 0f;
            player.GetComponentInChildren<PlayerLooking>().spinning = false;
        }
    }
    
    public void activate()
    {
        StartCoroutine(rotate());
    }
}
