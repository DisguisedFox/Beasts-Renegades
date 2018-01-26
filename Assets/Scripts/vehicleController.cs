using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleController : MonoBehaviour {
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform positionPlayer;
    [SerializeField]
    Transform bottom;
    private float timeMax = 5.0f;
    [SerializeField]
    LayerMask layerMaskFloor;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float floorSpace;
    [SerializeField]
    GameObject spawnPlayer;
    float speed = 8.0f;
    Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);

    Rigidbody2D rigid;
    // Use this for initialization


    void Start () {
        rigid = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(bottom.position, floorSpace, layerMaskFloor))
        rigid.velocity =new Vector2(0.0f,3.0f);
    }
    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Fire2"))
        {
            gameObject.SetActive(false);
            player.transform.position = spawnPlayer.transform.position;
            player.SetActive(true);
        }

        
         
        

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
                direction = Vector3.left;
            if (Input.GetAxis("Horizontal") > 0)
                direction = Vector3.right;


            transform.Translate(direction * speed * Time.deltaTime);
          
        }

        float forceJump = Input.GetAxis("Jump");
        forceJump *= 5.0f;
        if (direction.Equals(Vector3.right))
            direction = new Vector3(0.5f, 1.0f, 0.0f);
        else
        if (direction.Equals(Vector3.left))
            direction = new Vector3(-0.5f, 1.0f, 0.0f);
        else
            direction = new Vector3(0.0f, 1.0f, 0.0f);

        rigid.AddForce(direction * forceJump, ForceMode2D.Impulse);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(2000.0f, 0.0f));
            Destroy(bullet, 3.0f);
        }

      

        
       
    }
    private void OnEnable()
    {
       transform.position= new Vector3(positionPlayer.position.x,bottom.position.y);
    }

    
}
