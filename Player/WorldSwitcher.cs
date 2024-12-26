using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WorldSwitcher : MonoBehaviour
{
    public PlayerMovement player;
    public glitchy glitcher;
    //puzzles
    public Puzzle1 puzzle1;
    public Puzzle2 puzzle2;
    public ResetP3 puzzle3;
    public bool switchActive = false;
    //objects that change
    private GameObject[] walls;
    private GameObject[] floors;
    private GameObject[] wires;
    private GameObject[] plights;
    private GameObject[] sLights;
    public GameObject[] plushies;
    public GameObject[] pedestals;
    public GameObject Ilight;
    public GameObject Ilight2;
    Renderer render;
    Light lights;
    public Image switchIndicate;
    public Slider remainingSwitches;
    public TextMeshProUGUI dRemaining;
    public Image clipboardBackground;
    public TextMeshProUGUI clipboardText;
    bool working = false;
    // Start is called before the first frame update
    void Start()
    {
        remainingSwitches.value = player.switchRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        //changing between states
        remainingSwitches.value = player.switchRemaining;
        dRemaining.text = remainingSwitches.value.ToString();
        if (Input.GetMouseButtonDown(1) && player.switchRemaining > 0 && !player.overloaded && !player.inCutscene && !player.inMenu && player.contraption){
            StartCoroutine(glitch());
            switchActive = !switchActive;
            puzzle1.wallStateSwitch();
            puzzle1.lightStateSwitch();
            puzzle2.wireSwitch();
            changeWall();
            player.switchRemaining -= 1;
            //player.switchRemaining += 10;
            /*if(player.switchRemaining >= 100)
            {
                player.switchRemaining = 100;
            }*/

            print("switched to " + switchActive);
        }

        if (switchActive)
        {
            player.altState = true;
            switchIndicate.GetComponent<Image>().color = Color.green;


        }
        else
        {
            player.altState = false;
            switchIndicate.GetComponent<Image>().color = Color.red;
        }
    }
    //resets the world upon pressing restart
    public void resetWorld()
    {
        if (switchActive) {
        switchActive = !switchActive;
        }
        if (player.lastCheckpoint.GetComponent<SetSwitches>().checknum == 1)
        {
            puzzle1.resetLevel();
        }
        else if (player.lastCheckpoint.GetComponent<SetSwitches>().checknum == 2)
        {
            puzzle2.resetLevel(player);
            puzzle3.Reset();
        }
        else if (player.lastCheckpoint.GetComponent<SetSwitches>().checknum == 3)
        {
            puzzle3.Reset();
        }
        changeWall();
        puzzle2.brokenWires.SetActive(false);
        puzzle2.fixedWires.SetActive(true);
    }

    public IEnumerator glitch()
    {
        if (!working)
        {
            working = true;
            glitcher.flipIntensity = 1;
            glitcher.ColorIntensity = 1;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1);
            glitcher.flipIntensity = 0;
            glitcher.ColorIntensity = 0;
            working = false;
        }
    }
    public void changeWall()
    {
        //the different objects it changes
        walls = GameObject.FindGameObjectsWithTag("wall");
        floors = GameObject.FindGameObjectsWithTag("Floor");
        wires = GameObject.FindGameObjectsWithTag("wire");
        plights = GameObject.FindGameObjectsWithTag("pLights");
        sLights = GameObject.FindGameObjectsWithTag("sLights");
        //the colors it changes between
        //Color clGreen = new Color((51f/255f), (133f/255f), (51f/255f));
        Color clBlue = new Color((59f / 255f), (75f/ 255f), (115f/ 255f));
        //Color clOrange = new Color((255f / 255),(180f/255),(80f/255));
        Color clOrange = new Color((255f / 255), (160f / 255), (50f / 255));
        Color wireOrange = new Color((255f / 255), (150f / 255), (0f / 255));
        if (switchActive)
        {
            //to parallel
            //clipboard
            clipboardBackground.color = new Color((245f / 255f), (228f / 255f), (94f / 255f), (192f / 255f)); ;
            clipboardText.color = new Color((0f / 255f), (0f / 255f), (0f / 255f), (255f / 255f));
            //changing walls
            foreach (GameObject wall in walls)
            {
                render = wall.GetComponent<Renderer>();
                render.material.SetColor("_Color", Color.white);
            }
            //changing floors
            foreach (GameObject floor in floors)
            {
                render = floor.GetComponent<Renderer>();
                render.material.SetColor("_Color", Color.white);
            }
            //changes most lights
            foreach (GameObject light in plights)
            {
                lights = light.GetComponent<Light>();
                lights.color = clOrange;
                lights.range = 12;
                //lights.type = LightType.Point;
            }
            RenderSettings.ambientIntensity = .25f;
            //changes light connecting P1 and P2 differently
            foreach (GameObject light in sLights)
            {
                lights = light.GetComponent<Light>();
                //lights.color = clGreen;
                lights.color = clOrange;
            }
            //reveals broken connections for p2
            puzzle2.altConnections.SetActive(true);
            //changes wires for P2
            foreach (GameObject wire in wires)
            {
                render = wire.GetComponent<Renderer>();
                //render.material.SetColor("_Color", Color.green);
                //render.material.SetColor("_EmissionColor", Color.green);
                render.material.SetColor("_Color", wireOrange);
                render.material.SetColor("_EmissionColor", wireOrange);
            }
            //changes pillars for P2
            foreach (GameObject pillar in puzzle2.bPillars)
            {
                puzzle2.pStates[puzzle2.ci] = pillar.activeSelf;
                pillar.SetActive(true);
                render = pillar.GetComponent<Renderer>();
                render.material.SetColor("_Color", Color.white);
                puzzle2.ci++;
            }
            puzzle2.ci = 0;
            //changes wires on pillars for P2
            foreach (GameObject wire in puzzle2.bWires)
            {
                puzzle2.wStates[puzzle2.ci] = wire.activeSelf;
                wire.SetActive(true);
                wire.transform.parent.GetChild(2).gameObject.SetActive(false);
                wire.transform.parent.GetChild(3).gameObject.SetActive(false);
                render = wire.GetComponent<Renderer>();
                //render.material.SetColor("_Color", Color.green);
                //render.material.SetColor("_EmissionColor", Color.green);
                render.material.SetColor("_Color", wireOrange);
                render.material.SetColor("_EmissionColor", wireOrange);
                puzzle2.ci++;
            }
            puzzle2.ci = 0;
            //sets the color of indicator in P2
             Ilight.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
             Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 1, 0));
            //p3 indicator light
            Ilight2.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            Ilight2.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 1, 0));
            //p3 plushies appearing
            if (!player.plushHammerUnlock)
            {
                plushies[0].SetActive(true);
            }
            if (!player.plushBoxUnlock)
            {
                plushies[1].SetActive(true);
            }
            plushies[2].SetActive(true);
        }
        else
        {
            //to real
            //clipboard
            clipboardBackground.color = new Color(1, 1, 1, (192f / 255f));
            clipboardText.color = new Color((0f / 255f), (50f / 255f), (180f / 255f));
            //changing walls
            foreach (GameObject wall in walls)
            {
                render = wall.GetComponent<Renderer>();
                render.material.SetColor("_Color", Color.grey);
            }
            //changing floors
            foreach (GameObject floor in floors)
            {
                render = floor.GetComponent<Renderer>();
                render.material.SetColor("_Color", Color.grey);
            }
            //changes most lights
            foreach (GameObject light in plights)
            {
                lights = light.GetComponent<Light>();
                lights.color = clBlue;
                lights.range = 10;
                //lights.type = LightType.Spot;
            }
            RenderSettings.ambientIntensity = 0f;
            //changes light connecting P1 and P2 differently
            foreach (GameObject light in sLights)
            {
                lights = light.GetComponent<Light>();
                lights.color = clBlue;
                lights.range = 10;
            }
            //hides broken connections for p2
            puzzle2.altConnections.SetActive(false);
            //changes wires for P2
            foreach (GameObject wire in wires)
            {
                render = wire.GetComponent<Renderer>();
                render.material.SetColor("_Color", Color.blue);
                render.material.SetColor("_EmissionColor", Color.blue);
            }
            //changes pillars for P2
            foreach (GameObject pillar in puzzle2.bPillars)
            {
                pillar.SetActive(puzzle2.pStates[puzzle2.ci]);
                render = pillar.GetComponent<Renderer>();
                render.material.SetColor("_Color", Color.grey);
                puzzle2.ci++;
            }
            puzzle2.ci = 0;
            //changes wires on pillars for P2
            foreach (GameObject wire in puzzle2.bWires)
            {
                wire.SetActive(puzzle2.wStates[puzzle2.ci]);
                if (puzzle2.wStates[puzzle2.ci] == false)
                {
                    wire.transform.parent.GetChild(2).gameObject.SetActive(true);
                    wire.transform.parent.GetChild(3).gameObject.SetActive(true);
                }
                render = wire.GetComponent<Renderer>();
                render.material.SetColor("_Color", Color.blue);
                render.material.SetColor("_EmissionColor", Color.blue);
                puzzle2.ci++;
            }
            puzzle2.ci = 0;
            //sets the color of indicator in P2
            Ilight.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            //sets the color of indicator
            Ilight2.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 1));
            for (int i = 0; i < puzzle2.wStates.Length; i++)
            {
                if (puzzle2.wStates[i] == true)
                {
                    Ilight.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    Ilight.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 1));
                }
            }
            //p3 plushies disappearing
            if (!player.plushHammerUnlock)
            {
                plushies[0].SetActive(false);
            }
            if (!player.plushBoxUnlock)
            {
                plushies[1].SetActive(false);
            }
            plushies[2].SetActive(false);
            foreach(GameObject p in pedestals)
            {
                if(p.GetComponent<pedestals>().cObject == "Plush Pedestal")
                {
                    plushies[2].SetActive(true);
                }
            }
        }
    }
}
