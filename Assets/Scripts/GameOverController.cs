using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverController : MonoBehaviour {
    [SerializeField]
    Button play;
    [SerializeField]
    Button exit;
    [SerializeField]
    AudioSource btnSound;
 
    // Use this for initialization
    void Start()
    {
        play.onClick.AddListener(() => loadGame());
        exit.onClick.AddListener(() => exitGame());
        
    }

  
    // Update is called once per frame
    void Update()
    {

    }

  private  void loadGame()
    {
        btnSound.Play();
        //A changer pour loader la station en premier
        SceneManager.LoadScene(PlayerPrefs.GetString("lastLoadedScene"));
    }

   private void exitGame()
    {
        btnSound.Play();
        if (SceneManager.GetActiveScene().Equals("GameOver"))
            SceneManager.LoadScene("StartMenu");
        else
            Application.Quit();
    }
}

