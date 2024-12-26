using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class SetSwitches : MonoBehaviour
{
    public PlayerMovement player;
    public int uses = 1;
    public int originaluses = 1;
    public int maxAmount = 6;
    public int restoreAmount;
    public int timerAmount = 60;
    public Slider remainingSwitches;
    public TextMeshProUGUI dRemaining;
    public TextMeshProUGUI tRemaining;
    public int checknum;
    public AudioSource lvlMusic = null;
    public Animator lvl1 = null;
    public Animator lvl2 = null;
    public Restart restart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && uses > 0)
        {
            remainingSwitches.maxValue = maxAmount;
            player.switchRemaining = restoreAmount;
            remainingSwitches.value = player.switchRemaining;
            player.timer = timerAmount;
            player.lastCheckpoint = this.gameObject;
            dRemaining.text = remainingSwitches.value.ToString();
            tRemaining.text = timerAmount.ToString();
            uses -= 1;
            restart.once = true;
            if (lvlMusic != null)
            {
                lvlMusic.Play();
                lvlMusic.loop = true;
            }
            if (lvl1 != null)
            {
                lvl1.Play("Contraption Use");
            }
            if(lvl2 != null)
            {
                lvl2.Play("p2 explain");
            }
            if (player.lastCheckpoint.GetComponent<SetSwitches>().checknum == 4)
            {
                player.timerD.gameObject.SetActive(false);
            }
        }
    }
}
