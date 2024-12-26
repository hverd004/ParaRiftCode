using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    public PlayerMovement player;
    public Animator ani;
    public int info;

    [Header("Assistance Selector")]
    public Puzzle1 p1 = null;
    public bool p1helper;

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
        if (other.gameObject.CompareTag("Player"))
        {
            if(info == 1)
            {
                StartCoroutine("dialog1");
            }
            if (p1 != null)
            {
                if (p1helper && p1.p1help != 3 && player.altState)
                {
                    p1.p1help += 1;
                }
                if (p1.p1help == 3)
                {
                    StartCoroutine("help1");
                }
            }
        }
    }

    public IEnumerator dialog1()
    {
        ani.Play("Modifier Initial Meet");
        yield return new WaitForSeconds(15);
    }
    public IEnumerator dialog2()
    {
        yield return new WaitForSeconds(1);
    }
    public IEnumerator help1()
    {
        ani.Play("p1 Stuck Hint");
        yield return new WaitForSeconds(9);
    }
}
