using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
    [SerializeField]
    Button play;
    [SerializeField]
    Button exit;

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

    void loadGame()
    {
        //A changer pour loader la station en premier
        SceneManager.LoadScene("planete1");
    }

    void exitGame()
    {
        Application.Quit();
    }
}

