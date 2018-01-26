using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour {

    [SerializeField]
    Button Restartbutton;
    void Start()
    {
       Button Click = Restartbutton.GetComponent<Button>();
       Click.onClick.AddListener(Load);
    }
    void Load()
    {
        SceneManager.LoadScene("planete1");
    }
    public void Uptdate  () {

		
	}
}
