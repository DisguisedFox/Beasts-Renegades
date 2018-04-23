using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartController : MonoBehaviour {
    [SerializeField]
    Button play;
    [SerializeField]
    Button exit;
    [SerializeField]
    AudioSource btnSound;
    // Use this for initialization
    void Start ()
    {
        play.onClick.AddListener(() => loadGame());
        exit.onClick.AddListener(() => exitGame());
    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    void loadGame()
    {
        btnSound.Play();
        //A changer pour loader la station en premier
        SceneManager.LoadScene("station");
    }

    void exitGame()
    {
        btnSound.Play();
        Application.Quit();
    }
}
