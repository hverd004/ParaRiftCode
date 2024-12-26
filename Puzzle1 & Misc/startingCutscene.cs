using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingCutscene : MonoBehaviour
{
    public Animator start;
    public PlayerMovement player;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine("startWithTiming");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator startWithTiming()
    {
        yield return new WaitForSeconds(.25f);
        player.inMenu = false;
        start.Play("spawn Cutscene");
    }
}
