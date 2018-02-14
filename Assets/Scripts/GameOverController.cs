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
   
    Button next;
    // Use this for initialization
    void Start()
    {
        play.onClick.AddListener(() => loadGame());
        exit.onClick.AddListener(() => exitGame());
        if (gameObject.scene.Equals("Victory"))
        {
            next = GameObject.Find("Continue").GetComponent<Button>();
            next.onClick.AddListener(() => continueGame());
        }
    }

    private void continueGame()
    {
        //adapter la methode quand on aura toute les scènes du jeu
        if (!PlayerPrefs.GetString("lastLoadedScene").Equals("station"))
        {
            SceneManager.LoadScene("station");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

  private  void loadGame()
    {
        //A changer pour loader la station en premier
        SceneManager.LoadScene(PlayerPrefs.GetString("lastLoadedScene"));
    }

   private void exitGame()
    {
        Application.Quit();
    }
}

