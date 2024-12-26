using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public PlayerMovement player = null;
    public GameObject GameOver = null;
    public GameObject Pause = null;
    public GameObject clipboard = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && player.switchRemaining != 0 && player.timer != 0 && !player.inBoard)
        {
            player.inMenu = !player.inMenu;
            if (player.inMenu)
            {
                Pause.SetActive(true);
                Animator[] anisearch = FindObjectsOfType<Animator>();
                foreach(Animator ani in anisearch)
                {
                    ani.speed = 0;
                    //Time.timeScale = 0;
                }
            }
            else
            {
                Pause.SetActive(false);
                Animator[] anisearch = FindObjectsOfType<Animator>();
                foreach (Animator ani in anisearch)
                {
                    ani.speed = 1;
                    Time.timeScale = 1;
                }
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && player.switchRemaining != 0 && player.timer != 0 && player.inBoard)
        {
            player.inBoard = false;
            player.inMenu = false;
            player.Boardin.gameObject.SetActive(false);
        }
    }
    public void quitToMenu()
    {
        StartCoroutine(menuv());
    }

    public IEnumerator menuv()
    {
        yield return new WaitForSeconds(.01f);
        if (SceneManager.sceneCount == 1)
        {
            player.inMenu = false;
            Debug.Log("WHAT");
        }
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void beginGame()
    {
        SceneManager.LoadScene("GameScene");
        if (SceneManager.sceneCount == 1)
        {
            player.inMenu = false;
            Debug.Log("WHAT");
        }
    }

    public void loadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
