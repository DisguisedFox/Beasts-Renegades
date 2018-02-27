using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptP2 : MonoBehaviour {

    private GameObject[] getCount;
    int count = 0;

    // Update is called once per frame
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("enemyP2");
        count = getCount.Length;
        if (count <= 0)
        {
            Destroy(gameObject);
        }
    }
}
