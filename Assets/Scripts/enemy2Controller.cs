using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Controller : MonoBehaviour {

    [SerializeField]
    Transform playerPos;
    [SerializeField]
    Animator animator;
    [SerializeField]
   Camera principalCamera;
    bool facingRight = true;
    private float speed = 0.2f;
    private float distance = 0.5f;
    private float deltaTeleportPos = 2f;
    private float maxRange = 0.002f;
    private float deltaGun= 0.2f;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform gunPos;
    [SerializeField]
    GameObject effect;
    float counter_time = 0.0f;

    private Color baseColor;
    private SpriteRenderer render;
    bool gunPosUp = false;
    bool gunPosRight = true;
    bool gunPosLeft = false;
    bool coroutineLoading = false;
   
    // Use this for initialization
    void Start ()
    {
     
       
        render= GetComponent<SpriteRenderer>();
        baseColor = render.color;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveToPlayer();
        if (!coroutineLoading)
            StartCoroutine("Shoot");
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void MoveToPlayer()
    {

        if (gameObject.GetComponent<Renderer>().isVisible)
            {
                if (transform.position.y<playerPos.transform.position.y-0.5f)
                {
                animator.SetBool("horizontal", false);
                animator.SetBool("vertical", true);
                animator.SetBool("walking", true);
                if (!gunPosUp)
                {
                    gunPos.position = new Vector3(transform.position.x, transform.position.y + deltaGun);
                    gunPos.rotation = new Quaternion(0, 0, 0, 180);
                    gunPosUp = true;
                    gunPosRight = false;
                    gunPosLeft = false;
                }
                MoveUp();
            }
            else
            {
                if(transform.position.y > playerPos.transform.position.y + 0.5f)
                {
                    animator.SetBool("horizontal", false);
                    animator.SetBool("vertical", true);
                    animator.SetBool("walking", true);
                    if (!gunPosUp)
                    {
                        gunPos.position = new Vector3(transform.position.x, transform.position.y + deltaGun);
                        gunPos.rotation = new Quaternion(0, 0, 0, 180);
                        gunPosUp = true;
                        gunPosRight = false;
                        gunPosLeft = false;
                    }
                    TeleportBottom();
                }
                else
                {
                    if (transform.position.x < playerPos.transform.position.x - 0.5f)
                    {
                        animator.SetBool("horizontal", true);
                        animator.SetBool("vertical", false);
                        animator.SetBool("walking", true);
                        if (!facingRight)
                            Flip();

                        if (!gunPosRight)
                        {
                            gunPos.position = new Vector3(transform.position.x + deltaGun, transform.position.y);
                            gunPos.rotation = new Quaternion(0, 0, 0, 90);
                            gunPosUp = false;
                            gunPosRight = true;
                            gunPosLeft = false;
                        }
                        MoveRight();
                    }
                    else
                    {
                        if (transform.position.x > playerPos.transform.position.x + 0.5f)
                        {
                            animator.SetBool("horizontal", true);
                            animator.SetBool("vertical", false);
                            animator.SetBool("walking", true);
                            if (facingRight)
                                Flip();
                            if (!gunPosLeft)
                            {
                                gunPos.position = new Vector3(transform.position.x - deltaGun, transform.position.y );
                                gunPos.rotation = new Quaternion(0, 0, 0, 180);
                                gunPosUp = false;
                                gunPosRight = false;
                                gunPosLeft = true;
                            }
                            MoveLeft();
                        }
                    }
                }
            }
           
        }
    }

    private void MoveUp()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); 
    }
    private void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
    private void MoveLeft()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
    private void TeleportBottom()
    {
        counter_time += Time.deltaTime;
        if (counter_time >= 2f)
        {
            transform.position = new Vector2(transform.position.x, playerPos.position.y);
            counter_time = 0f;
        }
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
   
    private IEnumerator Shoot()
    {
       
            float speedBullet = 2.5f;
            coroutineLoading = true;
            float shootInterval = 3f;
            GameObject bullet1 = Instantiate(bullet, gunPos);
            bullet1.SetActive(true);
            Rigidbody2D rigidBullet = bullet1.GetComponent<Rigidbody2D>();
            if (gunPosUp)
                rigidBullet.AddForce(Vector2.up * speedBullet, ForceMode2D.Impulse);
            else
                if (gunPosLeft)
                rigidBullet.AddForce(Vector2.left * speedBullet, ForceMode2D.Impulse);
            else
                 if (gunPosRight)
                rigidBullet.AddForce(Vector2.right * speedBullet, ForceMode2D.Impulse);

            if (bullet!=null&&(bullet.transform.position.x >principalCamera.transform.position.x || bullet.transform.position.x < principalCamera.transform.position.x || bullet.transform.position.y > principalCamera.transform.position.y || bullet.transform.position.y <principalCamera.transform.position.y))
            {
                DestroyImmediate(bullet1);
            }
            else
            {
                Destroy(bullet1,3f);
            }
            yield return new WaitForSeconds(shootInterval);
            coroutineLoading = false;

        }

      
    
   
}
