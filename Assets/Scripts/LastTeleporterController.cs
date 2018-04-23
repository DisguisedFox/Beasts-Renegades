using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastTeleporterController : MonoBehaviour
{
    [SerializeField]
    AudioSource teleportSound;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            teleportSound.Play();
            StartCoroutine("PlaySound");

        }
    }

    private IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("station2");
    }
}
