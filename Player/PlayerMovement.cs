using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("General Settings")]
    float x = 0;
    float z = 0;
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public bool altState = false;
    public bool canMove = true;
    public TextMeshProUGUI currentItem;
    public TextMeshProUGUI timerD;
    public bool inCutscene = false;
    public bool keyCardUnlock = false;
    public bool inMenu = false;
    public bool swaping = false;
    public bool overloaded = false;
    public bool contraption = false;
    public AudioSource glitchaudio;
    public AudioSource walkaudio;
    public AudioSource jumpaudio;
    public AudioSource landaudio;
    public Animator earAnim;

    [Header("Endings")]
    public bool badEnd;

    [Header("Clipboard")]
    public bool inBoard = false;
    public GameObject Boardin;

    [Header("Health/Checkpoints")]
    public int switchRemaining = 0;
    public int timer = -1;
    public List<GameObject> checkpoints;
    public GameObject lastCheckpoint;

    [Header("Jump Settings")]
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isGrounded;
    public bool inAir = false;
    public bool doGravity;
    public float jumpHeight = 1.5f;
    public bool jumpPowered = false;

    [Header("Ladder Settings")]
    public bool onLadder = false;
    public float ladderSpeed = 2f;

    [Header("Hammer Settings")]
    public bool hammerUnlock = false;
    public string currentHammer = "Normal Hammer";
    public GameObject[] eWalls;

    [Header("Plush Settings")]
    public bool plushHammerUnlock = false;
    public bool plushBoxUnlock = false;
    public bool plushPillarUnlock = false;
    public bool plushCUnlock = false;

    private bool working = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //gravity
        if (doGravity && !inMenu && !(switchRemaining == 0) && !(timer == 0) && !onLadder && !swaping) {
            StartCoroutine(timerCount());
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        if (!(switchRemaining == 0) && !(timer == 0) && !inCutscene && !inMenu && !swaping)
        {
            //display current item when switching items 
            //hammer
            if (Input.GetKeyDown(KeyCode.Alpha1) /*&& correctState*/ && hammerUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = currentHammer;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) /*&& correctState*/ && !hammerUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "???";
            }
            //plush hammer
            else if (Input.GetKeyDown(KeyCode.Alpha2) /*&& correctState*/ && plushHammerUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "Plush Hammer";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) /*&& correctState*/ && !plushHammerUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "???";
            }
            //plush box
            else if (Input.GetKeyDown(KeyCode.Alpha3) /*&& correctState*/ && plushBoxUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "Plush Box";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) /*&& correctState*/ && !plushBoxUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "???";
            }
            //plush Pillar
            else if (Input.GetKeyDown(KeyCode.Alpha4) /*&& correctState*/ && plushPillarUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "Plush Pillar";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) /*&& correctState*/ && !plushPillarUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "???";
            }
            //plush Device
            else if (Input.GetKeyDown(KeyCode.Alpha5) /*&& correctState*/ && plushCUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "Plush Device";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) /*&& correctState*/ && !plushCUnlock)
            {
                currentItem.GetComponent<TextMeshProUGUI>().text = "???";
            }
            //input
                x = Input.GetAxis("Horizontal");
                z = Input.GetAxis("Vertical");
            if((x != 0 || z != 0) && isGrounded && !walkaudio.isPlaying)
            {
                walkaudio.Play();
            }
            else if ((x == 0 && z == 0) || !isGrounded)
            {
                walkaudio.Stop();
            }

            //ladder
            if (onLadder)
            {
                Vector3 wallMove = transform.right * x + transform.forward * z;
                if (Input.GetKey(KeyCode.Space))
                {
                    wallMove = wallMove + transform.up * 2;
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    wallMove = wallMove + transform.up * -2;
                }
                controller.Move(wallMove * ladderSpeed * Time.deltaTime);
            }
            //regular motion
            else
            {
                

                Vector3 move = transform.right * x + transform.forward * z;

                controller.Move(move * speed * Time.deltaTime);
                //jump
                if (currentItem.GetComponent<TextMeshProUGUI>().text == "Jump Boost")
                {
                    jumpHeight = 5f;
                }
                else
                {
                    jumpHeight = 1.5f;
                }
                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    jumpaudio.Play();
                    StartCoroutine(jumppause());
                }
                if(inAir && isGrounded)
                {
                    inAir = false;
                    landaudio.Play();
                }
            }
        }
        else
        {
            walkaudio.Stop();
            jumpaudio.Stop();
            landaudio.Stop();
        }
        /*StartCoroutine(cooldown());
        if (switchRemaining >= 100)
        {
            overloaded = true;
        }
        if (overloaded && switchRemaining == 0)
        {
            overloaded = false;
        }*/
    }

    public IEnumerator timerCount()
    {
        if (!working && timer > 0)
        {
            working = true;
            yield return new WaitForSeconds(1);
            timer -= 1;
            timerD.text = timer.ToString();
            working = false;
        }
    }
    public IEnumerator jumppause()
    {
        earAnim.SetBool("jumping", true);
        yield return new WaitForSeconds(.5f);
        inAir = true;
        earAnim.SetBool("jumping", false);
    }
}
