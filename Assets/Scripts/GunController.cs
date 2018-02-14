using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    AudioSource blasterSound;
    [SerializeField]
    GameObject bulletPrefab;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet;
            blasterSound.Play();
            bullet=Instantiate(bulletPrefab,bulletPrefab.transform.position,gameObject.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(4000.0f, 0.0f));
            Destroy(bullet, 3.0f);
        }
    }
  
}