using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {




    private Vector3 positionInitial;
    [SerializeField]
    GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
        StartCoroutine(shooting());
    }

    IEnumerator shooting()
    {
        while (true)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletPrefab.transform.right * 4.0f;
            Destroy(bullet, 3.0f);
            yield return new WaitForSeconds(3.0f);
        }


    }
    // Update is called once per frame
    void Update () {
		
	}
}
