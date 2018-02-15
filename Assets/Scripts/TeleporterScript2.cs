using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript2 : MonoBehaviour {

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
            if (PlayerPrefs.GetString("lastLoadedScene").Equals("planete1"))
            {
                teleporter1.gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetString("lastLoadedScene").Equals("planete2"))
            {
                teleporter2.gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetString("lastLoadedScene").Equals("planete3"))
            {
                boss.SetActive(true);
                teleporter1.gameObject.SetActive(false);
                teleporter2.gameObject.SetActive(false);
                teleporter3.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("je suis dessus2");
            boss.SetActive(true);
            //SceneManager.LoadScene("planete2");
        }
    }
}
