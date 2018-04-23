using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos1 = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos1;
        float angle1 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle1, Vector3.forward);





    }
}
