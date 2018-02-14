using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    bool isPaused = false;
    [SerializeField]
    GameObject canvasPause;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("pauseButton"))
        {
            if (!isPaused)
            {
                
                canvasPause.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
            }
            else
            {
                canvasPause.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;

            }

        }
    }
}
