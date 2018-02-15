using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController1 : MonoBehaviour {
    //bool isflipped=false;
    //Animator animator;
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
    [SerializeField]
    GameObject spawnPlayer;

    [SerializeField]
    GameObject inventory;
    [SerializeField]
     float jumpTime;
    [SerializeField]
     float jumpTimeCounter;
    [SerializeField]
    bool stoppedJumping;

    Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);
    bool inventoryOpen=false;
    private static int playerLifes = 10;
    Rigidbody2D rigid;

    float speed = 6.0f;

    bool touchFloor=true;
    [SerializeField]
    float jumpForce = 6.0f;

    
    // Use this for initialization
    void Start ()
    {
        
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        rigid = GetComponent<Rigidbody2D>();
     //animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        
        ToggleInventory();
        //Change from normal player to vehicle
        if(Input.GetButtonDown("Fire2"))
        {
            gameObject.SetActive(false);
            Vehicle.transform.position = spawnPlayer.transform.position;

            Vehicle.SetActive(true);
        }

        if (!inventoryOpen)
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
                direction = new Vector3(0.0f, 1.0f, 0.0f);

        }
        touchFloor = Physics2D.OverlapCircle(positionRaycastJump.position, radiusRaycastJump, layerMaskJump);
        if (touchFloor)
        {
           
                //the jumpcounter is whatever we set jumptime to in the editor.
                jumpTimeCounter = jumpTime;
            


            /*  if (forceJump != 0)
              {
                  animator.SetBool("isJumping", true);
              }
              else
              {

                 animator.SetBool("isJumping", false);

              }*/
        }

       
        lifes.text="Lifes : "+playerLifes;
        // if(horizatalInput!=0)
        //{ animator.SetBool("walk", true); }

    }
    void FixedUpdate()
    {
        //I placed this code in FixedUpdate because we are using phyics to move.

        //if you press down the mouse button...
        if (Input.GetAxis("Jump") > 0)
        {
            //and you are on the ground...
            if (touchFloor)
            {
                //jump!
                rigid.velocity = new Vector2(direction.x, jumpForce);
                stoppedJumping = false;
            }
        }

        //if you keep holding down the mouse button...
        if ((Input.GetAxis("Jump") > 0) && !stoppedJumping)
        {
            //and your counter hasn't reached zero...
            if (jumpTimeCounter > 0)
            {
                //keep jumping!
                rigid.velocity = new Vector2(direction.x,jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }


        //if you stop holding down the mouse button...
        if (Input.GetAxis("Jump")==0 )
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
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

        if (collision.gameObject.tag.Equals("spikes"))
        {
                SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("water"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public static int getPlayerLifes()
    {
        return playerLifes;
    }

    private void OnEnable()
    {
       
        playerLifes = vehicleController.getPlayerLifes();
    }

    public void ToggleInventory()
    {
        if (!inventory.activeSelf && Input.GetButtonDown("backButton"))
        {
            inventory.SetActive(true);
            inventoryOpen = true;


        }
        else
        {
            if (Input.GetButtonDown("backButton"))
            {
                inventory.SetActive(false);
                inventoryOpen = false;
            }
        }


    }
}
