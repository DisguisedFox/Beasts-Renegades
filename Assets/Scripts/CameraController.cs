using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject vehicle;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.activeSelf)
            transform.position = player.transform.position;
        else
            transform.position = vehicle.transform.position;

    }
}
