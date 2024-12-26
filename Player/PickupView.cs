using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PickupView : MonoBehaviour
{
    public GameObject pCam;
    public bool carrying;
    public GameObject carriedObject;
    public float smooth;
    public Material old;
    public Material highlight;
    public int once = 1;
    public GameObject overlays;
    public int movePower;
    public int z = 100;
    public AudioSource pickupsound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if (carrying)
        {
            //sets the physics of the cube when carried and moves the cube
            carriedObject.GetComponent<Rigidbody>().useGravity = false;
            carriedObject.GetComponent<Rigidbody>().drag = smooth;
            if (Vector3.Distance(carriedObject.transform.position, pCam.transform.GetChild(0).position) > 0.1f) {
                Vector3 moveDirection = (pCam.transform.GetChild(0).position - carriedObject.transform.position);
                carriedObject.GetComponent<Rigidbody>().AddForce(moveDirection * movePower);
            }
            //drops the cube
            if (Input.GetKeyDown(KeyCode.E)) {
                drop();
            }
        }
      else
        {
            //picks up the cube
            pickup();
        }
    }

    void drop()
    {
        //returns cube physics and materials to normal
        carriedObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.GetComponent<Rigidbody>().drag = 0;
        carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        carriedObject.layer = LayerMask.NameToLayer("Ground");
        carriedObject.GetComponent<MeshRenderer>().material = old;
        carrying = false;
        carriedObject = null;
        once = 1;
    }
    void pickup()
    {
        //makes the raycast
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        Ray ray = pCam.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y, z));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.transform.name);
            //checks what they player is looking at
            bool carry = hit.collider.CompareTag("carry");
            bool pickup = hit.collider.CompareTag("pickUp");
            bool interact = hit.collider.CompareTag("interact");
            bool clipboard = hit.collider.CompareTag("clipboard");
            float distance = hit.distance;
            //picks up objects like cubes
            if (carry)
            {
                carriedObject = hit.collider.gameObject;
                //ensures the materials get changed once
                if (once > 0)
                {
                    old = carriedObject.GetComponent<MeshRenderer>().material;
                    carriedObject.GetComponent<MeshRenderer>().material = highlight;
                    overlays.transform.GetChild(0).gameObject.SetActive(true);
                    overlays.transform.GetChild(1).gameObject.SetActive(false);
                    overlays.transform.GetChild(2).gameObject.SetActive(false);
                    once = 0;
                }
                //starts carrying the object
                if (Input.GetKeyDown(KeyCode.E))
                {
                    carrying = true;
                    carriedObject.layer = LayerMask.NameToLayer("Grabbed");
                }
            }
            //if the player is looking at an item
            else if (pickup && distance < 2)
            {
                //sets ui elements
                //hammer
                try
                {
                  if (hit.collider.gameObject.GetComponent<HammerUnlock>().inRange)
                    {
                        overlays.transform.GetChild(0).gameObject.SetActive(false);
                        overlays.transform.GetChild(1).gameObject.SetActive(true);
                        overlays.transform.GetChild(2).gameObject.SetActive(false);
                        once = 0;
                    }
                    else
                    {
                        try
                        {
                            overlays.transform.GetChild(0).gameObject.SetActive(false);
                            overlays.transform.GetChild(1).gameObject.SetActive(false);
                            overlays.transform.GetChild(2).gameObject.SetActive(false);
                            once = 1;
                        }
                        catch { }
                    }
                    if (Input.GetKeyDown(KeyCode.E)) {
                        hit.collider.gameObject.GetComponent<HammerUnlock>().pickup();
                        pickupsound.Play();
                    }
                }
                catch { }
                //plush hammer
                try
                {
                    if (hit.collider.gameObject.GetComponent<PlushHammerUnlock>().inRange)
                    {
                        overlays.transform.GetChild(0).gameObject.SetActive(false);
                        overlays.transform.GetChild(1).gameObject.SetActive(true);
                        overlays.transform.GetChild(2).gameObject.SetActive(false);
                        once = 0;
                    }
                    else
                    {
                        try
                        {
                            overlays.transform.GetChild(0).gameObject.SetActive(false);
                            overlays.transform.GetChild(1).gameObject.SetActive(false);
                            overlays.transform.GetChild(2).gameObject.SetActive(false);
                            once = 1;
                        }
                        catch { }
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<PlushHammerUnlock>().pickup();
                        pickupsound.Play();
                    }
                }
                catch { }
                //plush Box
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(true);
                    overlays.transform.GetChild(2).gameObject.SetActive(false);
                    once = 0;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<PlushBoxUnlock>().pickup();
                        pickupsound.Play();
                    }
                }
                catch { }
                //keycard
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(true);
                    overlays.transform.GetChild(2).gameObject.SetActive(false);
                    once = 0;
                    if (Input.GetKeyDown(KeyCode.E))
                     {
                        hit.collider.gameObject.GetComponent<KeyCardUnlock>().pickup();
                        pickupsound.Play();
                    }
                   }
                catch {}
                //contraption
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(true);
                    overlays.transform.GetChild(2).gameObject.SetActive(false);
                    once = 0;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<ContraptionUnlock>().pickup();
                        pickupsound.Play();
                    }
                }
                catch { }
                //plush contraption
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(true);
                    overlays.transform.GetChild(2).gameObject.SetActive(false);
                    once = 0;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<PlushContraptionUnlock>().pickup();
                        pickupsound.Play();
                    }
                }
                catch { }
            }
            //if it is an interacted item like switch/modifier
            else if (interact && distance < 2)
            {
                //switch
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(false);
                    overlays.transform.GetChild(2).gameObject.SetActive(true);
                    once = 0;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<SolutionCheck>().check();
                        hit.collider.gameObject.GetComponent<SolutionCheck>().opening();
                    }
                }
                catch { }
                //final pedestal
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(false);
                    overlays.transform.GetChild(2).gameObject.SetActive(true);
                    once = 0;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<FinalPedestal>().place();
                        hit.collider.gameObject.GetComponent<FinalSolutionCheckP3>().check();
                    }
                }
                catch { }
                //pedestals
                try
                {
                    if (hit.collider.gameObject.GetComponent<pedestals>().inRange)
                    {
                        overlays.transform.GetChild(0).gameObject.SetActive(false);
                        overlays.transform.GetChild(1).gameObject.SetActive(false);
                        overlays.transform.GetChild(2).gameObject.SetActive(true);
                        once = 0;
                    }
                    else
                    {
                        try
                        {
                            overlays.transform.GetChild(0).gameObject.SetActive(false);
                            overlays.transform.GetChild(1).gameObject.SetActive(false);
                            overlays.transform.GetChild(2).gameObject.SetActive(false);
                        }
                        catch { }
                    }
                }
                catch { }
                //modifier
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(false);
                    overlays.transform.GetChild(2).gameObject.SetActive(true);
                    once = 0;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<Modifier>().activate();
                    }
                }
                catch { }
                //Directional modifier
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(false);
                    overlays.transform.GetChild(2).gameObject.SetActive(true);
                    once = 0;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<DirectionModifier>().activate();
                    }
                }
                catch { }

            }
            else if (clipboard && distance < 2)
            {
                try
                {
                    overlays.transform.GetChild(0).gameObject.SetActive(false);
                    overlays.transform.GetChild(1).gameObject.SetActive(false);
                    overlays.transform.GetChild(2).gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.gameObject.GetComponent<Clipboard>().clipboardstart();
                    }
                }
                catch { }
            }
            //if looking at nothing
            else
            {
                overlays.transform.GetChild(0).gameObject.SetActive(false);
                overlays.transform.GetChild(1).gameObject.SetActive(false);
                overlays.transform.GetChild(2).gameObject.SetActive(false);
                once = 1;
                try
                {
                    carriedObject.GetComponent<MeshRenderer>().material = old;
                }
                catch { }
            }
        }
    }
}
