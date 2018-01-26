using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseController : MonoBehaviour {

    [SerializeField]
    Button play;
    [SerializeField]
    Button exit;
    [SerializeField]
    GameObject canvasPause;
    [SerializeField]
    GameObject canvasGame;
    bool continueBtn = true;
    // Use this for initialization
    void Start()
    {
        play.Select();
        play.onClick.AddListener(() => loadGame());
        exit.onClick.AddListener(() => exitGame());
    }

    // Update is called once per frame
    void Update()
    {
        canvasGame.SetActive(false);
       if(Input.GetAxis("Vertical")!=0)
        {
            if(continueBtn)
            {
                exit.Select();
                continueBtn = false;
            }
            else
            {
                play.Select();
                continueBtn = true;
            }
        }
    }

    void loadGame()
    {
        //A changer pour loader la station en premier
        Time.timeScale = 1;
            canvasGame.SetActive(true);
            canvasPause.SetActive(false);
        
    }

    void exitGame()
    {
        Application.Quit();
    }
}


