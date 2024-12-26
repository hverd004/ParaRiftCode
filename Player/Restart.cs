using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public PlayerMovement playerscript;
    public GameObject player;
    public GameObject GameOver;
    public SetSwitches checkpointScript;
    public WorldSwitcher world;
    public GameObject explode;
    public bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerscript.switchRemaining == 0 || playerscript.timer == 0)
        {
            GameOver.SetActive(true);
            boom();
        }
        else
        {
            GameOver.SetActive(false);
        }
    }
    public void restart()
    {
        checkpointScript = playerscript.lastCheckpoint.GetComponent<SetSwitches>();
        checkpointScript.uses = checkpointScript.originaluses;
        playerscript.altState = false;
        world.resetWorld();
        player.transform.position = playerscript.lastCheckpoint.transform.position;
        player.transform.rotation = Quaternion.Euler(0,0, 0);
    }
    public void boom()
    {
        if (once)
        {
            explode.GetComponent<ParticleSystem>().Play();
        }
        once = false;
    }

}
