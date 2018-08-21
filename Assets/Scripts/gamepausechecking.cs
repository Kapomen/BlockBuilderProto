using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamepausechecking : MonoBehaviour {
    public bool paused;

    public GameObject pausebutton;
    public GameObject resetbutton;
    

    //public GameObject resultmenu;

	// Use this for initialization
	void Start () {
       
        paused = false;
        GameObject timer = GameObject.Find("Timer");

        TimerCounting timerreset = timer.GetComponent<TimerCounting>();

        pausebutton = GameObject.Find("Pause");
        resetbutton = GameObject.Find("Reset");
    }
	
	// Update is called once per frame
	void Update () {
        if(paused == false)
        {
            pausebutton.SetActive(true);
            resetbutton.SetActive(true);
        }

    }

    public void Pause()
    {
        pausebutton.SetActive(false);
        resetbutton.SetActive(false);
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
    }

   
}
