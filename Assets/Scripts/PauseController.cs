using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    [SerializeField]
    Button play;
    [SerializeField]
    Button exit;
    [SerializeField]
    Transform PlayerTransform;
    [SerializeField]
    GameObject canvasPause;
    
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

        transform.position = PlayerTransform.position;
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
            canvasPause.SetActive(false);
        
    }

    void exitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}


