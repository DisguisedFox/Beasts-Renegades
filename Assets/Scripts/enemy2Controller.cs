using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Controller : MonoBehaviour {

    [SerializeField]
    Transform playerPos;
    [SerializeField]
    Animator animator;
    bool facingRight = true;
    private float speed = 0.2f;
    private float distance = 0.5f;
    private float deltaTeleportPos = 2f;
    private float maxDistance = 3.15f;
    private float deltaGun= 0.2f;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform gunPos;
    [SerializeField]
    GameObject effect;

    
    private Color baseColor;
    private SpriteRenderer render;
    bool gunPosUp = false;
    bool gunPosRight = true;
    bool gunPosLeft = false;
    bool coroutineLoading = false;
    TeleportState enemyTeleportState;
    enum TeleportState
    {
        NOTHING,
        TRANSPOSITION,
        WAITINTERVAL,
        TELEPORTATION,
        BLINKING
    }
    // Use this for initialization
    void Start ()
    {
     
        enemyTeleportState=TeleportState.NOTHING;
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
        float diffX= Mathf.Abs(transform.InverseTransformPoint(playerPos.transform.position).x);
        float diffY = Mathf.Abs(transform.InverseTransformPoint(playerPos.transform.position).y);

        if (diffX <= maxDistance || diffY <= maxDistance)
        {
            if ((diffY>distance) &&transform.position.y<playerPos.transform.position.y)
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
                if((diffY>distance)&& transform.position.y > playerPos.transform.position.y)
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
                    if ((diffX > distance) && transform.position.x < playerPos.transform.position.x)
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
                        if ((diffX > distance) && transform.position.x > playerPos.transform.position.x)
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
        switch(enemyTeleportState)
        {
            case TeleportState.NOTHING:
                effect.SetActive(true);
                StartCoroutine("Blink");
                break;
            case TeleportState.TRANSPOSITION:
                StartCoroutine("TransposeEffect");
                break;
            case TeleportState.TELEPORTATION:
                TransposeEnemy();
                break;
           
        }
       
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private IEnumerator Blink()
    {
        enemyTeleportState = TeleportState.BLINKING;
        float duration = 4f;
        float time = Time.time;
       
        while (Time.time - time < duration)
        {
            yield return new WaitForSeconds(0.5f);
            render.color = Color.clear;
            yield return new WaitForSeconds(0.5f);
            render.color = baseColor;
        }
        render.color = Color.clear;
        enemyTeleportState = TeleportState.TRANSPOSITION;
    }
    private IEnumerator Shoot()
    {
        float speedBullet = 3f;
        coroutineLoading = true;
        float shootInterval = 3f;
        GameObject bullet1 = Instantiate(bullet,gunPos);
        bullet1.SetActive(true);
        Rigidbody2D rigidBullet = bullet1.GetComponent<Rigidbody2D>() ;
        if (gunPosUp)
            rigidBullet.AddForce(Vector2.up*speedBullet, ForceMode2D.Impulse);
        else
            if(gunPosLeft)
                rigidBullet.AddForce(Vector2.left * speedBullet, ForceMode2D.Impulse);
        else
             if (gunPosRight)
            rigidBullet.AddForce(Vector2.right * speedBullet, ForceMode2D.Impulse);

        Destroy(bullet1, 4f);
        yield return new WaitForSeconds(shootInterval);
        coroutineLoading = false;
    }
    private IEnumerator TransposeEffect()
    {
        render.color = Color.red;
        effect.transform.position = transform.position + new Vector3(0, playerPos.position.y - deltaTeleportPos);
        enemyTeleportState = TeleportState.WAITINTERVAL;
        yield return new WaitForSeconds(2f);
        enemyTeleportState = TeleportState.TELEPORTATION;
        render.color = baseColor;
    }
    private void TransposeEnemy()
    {
        effect.SetActive(false);
        transform.position = effect.transform.position;
        enemyTeleportState = TeleportState.NOTHING;
    }
}
