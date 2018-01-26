using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleController : MonoBehaviour {
  
    [SerializeField]
    Transform positionPlayer;
    [SerializeField]
    Transform bottom;
    private float timeMax = 5.0f;
   
    [SerializeField]
    GameObject bulletPrefab;
   
   
    float speed = 8.0f;
    Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);
    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {

      


        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
                direction = Vector3.left;
            if (Input.GetAxis("Horizontal") > 0)
                direction = Vector3.right;


            transform.Translate(direction * speed * Time.deltaTime);

        }


        if (Input.GetAxis("Fire1")>0)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000.0f, 0.0f));
            Destroy(bullet, 3.0f);
        }

      

        
       
    }
    private void OnEnable()
    {
       transform.position= new Vector3(positionPlayer.position.x,bottom.position.y);
    }

    
}
