using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] lights;
    public int p1help;
    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("MazeLight");
        foreach (GameObject light in lights) 
        {
            if (light.name == "Mazelightalt")
            {
                light.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void wallStateSwitch()
    {
        foreach (GameObject wall in walls)
        {
            if (wall.activeSelf)
            {
                wall.SetActive(false);
            }
            else
            {
                wall.SetActive(true);
            }
        }
    }
    public void lightStateSwitch()
    {

        foreach (GameObject light in lights)
        {
            if (light.activeSelf)
            {
                light.SetActive(false);
            }
            else
            {
                light.SetActive(true);
            }
        }
    }

    public void resetLevel()
    {
        foreach (GameObject light in lights)
        {
            if (light.name == "Mazelightalt" && light.activeSelf)
            {
                wallStateSwitch();
                lightStateSwitch();
            }
        }
    }
}
