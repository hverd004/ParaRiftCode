using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badEnding : MonoBehaviour
{
    public FinalPedestal p = null;
    public GameObject explode = null;
    public GameObject[] block = null;
    public PlayerMovement player = null;
    public Animator ani = null;
    public bool correct;
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
        if (other.gameObject.CompareTag("Player") && p.cObject == "Device")
        {
            foreach (GameObject b in block)
            {
                b.gameObject.SetActive(true);
            }
            ani.Play("Bad Ending");
            player.badEnd = true;
        }
    }

    public void badE()
    {
        explode.GetComponent<ParticleSystem>().Play();
        SceneManager.LoadScene("End Bad");
    }
}