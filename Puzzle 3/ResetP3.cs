using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ResetP3 : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject leBox;
    public GameObject plushPedestal;
    public GameObject[] badEndingLock;
    public GameObject indication;
    public PlayerMovement player;
    public FinalSolutionCheckP3 switchlock;
    public Vector3 BoxPos;
    public Vector3 plushPos;
    public GameObject[] pedestal;
    public GameObject[] plushies;
    public GameObject[] rooms;
    public GameObject[] p3s3locks;
    // Start is called before the first frame update
    void Start()
    {
        BoxPos = new Vector3(-99.73200225830078f,-21.450000762939454f,-6.429999351501465f);
        plushPos = new Vector3(-100.0f,2.1999998092651369f,-14.399999618530274f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        foreach (GameObject wall in walls)
        {
            if (!wall.activeSelf)
            {
                wall.SetActive(true);
            }
        }

        foreach (GameObject p in pedestal)
        {
            if (p.transform.GetChild(7).gameObject.activeSelf)
            {
                p.transform.GetChild(7).gameObject.SetActive(false);
            }
            if (p.transform.GetChild(8).gameObject.activeSelf)
            {
                p.transform.GetChild(8).gameObject.SetActive(false);
            }
            if (p.GetComponent<pedestals>() != null)
            {
                p.GetComponent<pedestals>().cObject = "";
                p.GetComponent<pedestals>().active = false;
            }
            else if (p.GetComponent<FinalPedestal>() != null)
            {
                p.GetComponent<FinalPedestal>().cObject = "";
                p.GetComponent<FinalPedestal>().active = false;
            }
        }
        foreach (GameObject l in p3s3locks)
        {
            l.gameObject.SetActive(true);
        }
        player.plushBoxUnlock = false;
        player.plushCUnlock = false;
        player.plushHammerUnlock = false;
        player.plushPillarUnlock = false;
        player.currentItem.text = "";
        foreach (GameObject l in badEndingLock)
        {
            l.gameObject.SetActive(false);
        }
        player.contraption = true;
        indication.SetActive(true);
        switchlock.correct = false;
        foreach (GameObject r in rooms)
        {
            r.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        leBox.transform.position = BoxPos;
        plushPedestal.transform.position = plushPos;
    }
}
