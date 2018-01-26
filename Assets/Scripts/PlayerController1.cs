using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController1 : MonoBehaviour {
    //bool isflipped=false;
    Animator animator;
    [SerializeField]
    private Transform positionRaycastJump;
    [SerializeField]
    private float radiusRaycastJump;
    [SerializeField]
    private LayerMask layerMaskJump;
    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float force = 10.0f;
    [SerializeField]
    Text lifes;
    [SerializeField]
    GameObject Vehicle;

    Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);

    int playerLifes = 10;
    Rigidbody2D rigid;

    float speed = 6.0f;
    
    // Use this for initialization
    void Start ()
    {
        
        rigid = GetComponent<Rigidbody2D>();
     animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Change from normal player to vehicle
        if(Input.GetAxis("Fire2")>0)
        {
            gameObject.SetActive(false);
            Vehicle.SetActive(true);
        }
       
        bool touchFloor = Physics2D.OverlapCircle(positionRaycastJump.position, radiusRaycastJump, layerMaskJump);
        if (touchFloor)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                if (Input.GetAxis("Horizontal") < 0)
                    direction = Vector3.left;
                if (Input.GetAxis("Horizontal") > 0)
                    direction = Vector3.right;


                transform.Translate(direction * speed * Time.deltaTime);

            }
            else
                direction = new Vector3(0.0f,1.0f,0.0f);


    float forceJump =  Input.GetAxis("Jump");
            forceJump *= force;
            if (direction.Equals(Vector3.right))
                direction = new Vector3(0.5f, 1.0f, 0.0f);
            if (direction.Equals(Vector3.left))
                direction = new Vector3(-0.5f, 1.0f, 0.0f);
            rigid.AddForce(direction * forceJump, ForceMode2D.Impulse);

            if (forceJump != 0)
            {
                //animator.SetBool("isJumping", true);
            }
            else
            {

               // animator.SetBool("isJumping", false);

            }
        }

        lifes.text="Lifes : "+playerLifes;
        // if(horizatalInput!=0)
        //{ animator.SetBool("walk", true); }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("enemyBullet"))
        {
            Destroy(collision.gameObject);
            playerLifes--;
            if (playerLifes == 0)
                SceneManager.LoadScene("GameOver");
        }
    }

    
}
