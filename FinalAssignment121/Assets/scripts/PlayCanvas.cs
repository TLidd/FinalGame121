using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayCanvas : MonoBehaviour
{
    public Text text;
    public static int TotalTime;
    private float seconds;
    private int minutes;

    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        seconds = 0;
        minutes = 0;
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        int displaySeconds = (int)seconds;
        TotalTime = (int)seconds;
        if(displaySeconds == 60)
        {
            seconds = 0;
            minutes++;
        }
        if(minutes == 0)
        {
            text.text = displaySeconds.ToString();
        }
        else
        {
            if(displaySeconds < 10)
            {
                text.text = minutes.ToString() + ":" + "0" + displaySeconds.ToString();
            }
            else
            {
                text.text = minutes.ToString() + ":" + displaySeconds.ToString();
            }
        } 
        if(!Player.PlayerAlive)
        {
            if(minutes > 0)
            {
                EndCanvas.text = minutes.ToString() + " minutes and " + displaySeconds + " seconds";
            }
            else
            {
                EndCanvas.text = text.text + " seconds";
            }
            SceneManager.LoadScene("EndState");
        }
        if(!spawned)
        {
            if(displaySeconds % 6 == 0 && !spawned)
            {
                if(Platform.spawnAmount <= 25)
                {
                   Platform.spawnAmount++; 
                }
                spawned = true;
            }
        }
        if(displaySeconds % 6 != 0)
        {
            spawned = false;
        }
    }
}
