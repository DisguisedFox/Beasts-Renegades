using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelimitationController : MonoBehaviour {
    [SerializeField]
    GameObject part2;
    [SerializeField]
    GameObject part3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            if (!part2.activeSelf)
                part2.SetActive(true);
            else
            {
                part3.SetActive(true);
            }
        }
    }
}
