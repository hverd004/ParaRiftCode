using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLooking : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBody;
    private float xRotation = 0;
    public PlayerMovement player;
    public bool spinning;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!(player.switchRemaining == 0) && !(player.timer == 0) && !player.inMenu && !spinning && SceneManager.sceneCount == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (!player.inCutscene)
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseX);
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
