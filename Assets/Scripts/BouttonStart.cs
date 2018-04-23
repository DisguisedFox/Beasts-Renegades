using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartBoutton : MonoBehaviour {

    [SerializeField]
    Button Restartbutton;
    void Start()
    {
       Button Click = Restartbutton.GetComponent<Button>();
       Click.onClick.AddListener(Load);
    }
    void Load()
    {
        SceneManager.LoadScene("station");
    }
    public void Uptdate  () {

		
	}
}
