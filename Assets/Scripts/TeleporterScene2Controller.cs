using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScene2Controller : MonoBehaviour {
    [SerializeField]
    Transform nextPos;
    [SerializeField]
    GameObject vehicle;
    [SerializeField]
    GameObject player;
    [SerializeField]
    AudioSource teleportSound;

    Camera cameraMain;
    float foVInitial;
    float fullMapFoV = 95.8f;
    // Use this for initialization
    void Start ()
    {
        if (vehicle.activeSelf)
            cameraMain = vehicle.GetComponentInChildren<Camera>();
        else
            cameraMain = player.GetComponentInChildren<Camera>();

        foVInitial = cameraMain.fieldOfView;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine("CameraAnim", collision.gameObject);
            teleportSound.Play();
        }
    }

    private IEnumerator CameraAnim(GameObject player)
    {
        while (cameraMain.fieldOfView < fullMapFoV)
        {
            yield return new WaitForSeconds(0.009f);
            cameraMain.fieldOfView=cameraMain.fieldOfView+5f;
        }
        yield return new WaitForSeconds(1f);
        player.transform.position = nextPos.position;

        while (cameraMain.fieldOfView > foVInitial)
        {
            yield return new WaitForSeconds(0.009f);
            cameraMain.fieldOfView = cameraMain.fieldOfView - 5f;
        }

    }
}
