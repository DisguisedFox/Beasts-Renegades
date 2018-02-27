using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    private GameObject[] getCount;
    int count = 0;

    // Update is called once per frame
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("enemy");
        count = getCount.Length;
        if (count <= 0)
        {
            Destroy(gameObject);
        }
    }
}
