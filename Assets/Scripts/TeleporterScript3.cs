using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript3 : MonoBehaviour {

    [SerializeField]
    private Transform teleporter1;
    [SerializeField]
    private Transform teleporter2;
    [SerializeField]
    private Transform teleporter3;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private Transform player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("lastLoadedScene"))
        {
            //voir pr la station
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("je suis dessus3");
            //SceneManager.LoadScene("planete3");
        }
    }
}
