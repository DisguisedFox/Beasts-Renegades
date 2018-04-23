using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    AudioSource heartSound;
    [SerializeField]
    Canvas canvasUI;
    [SerializeField]
    private float speed;
    [SerializeField]
    private AudioSource shieldSound;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject bulletSpawner;
    private float space = 0.1f;
    private Vector2 direction;
    [SerializeField]
    private Sprite spriteUp;
    [SerializeField]
    private Sprite spriteDown;
    [SerializeField]
    private Sprite spriteLeft;
    [SerializeField]
    private Sprite spriteRight;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    Canvas pauseCanvas;
    private bool invincible = false;
    private int playerLifes = 3;
    [SerializeField]
    private Text textLifes;
    private const string TEXT_LIFES = "Lifes : ";

    [SerializeField]
    GameObject inventory;
    [SerializeField]
    Image shieldBar;
    [SerializeField]
    GameObject shield;
    public static float speedBullet=2.5f;
    static bool isAtRight=false;
   static bool isAtUp = false;
    static bool isAtBottom= true;
   static bool isAtLeft= false;
    bool sceneStart = true;
    [SerializeField]
    GameObject vehicle;
    
    // Use this for initialization
    [SerializeField]
    private SpriteRenderer weapon;
    private bool coroutineIsLooping = false;
    private SpriteRenderer rend;
    void Start()
    {
        rend=GetComponent<SpriteRenderer>();
        StartCoroutine("ShieldVariate");
        if (sceneStart)
        {
            if (SceneManager.GetActiveScene().name.Equals("station2"))
            {

                PlayerPrefs.SetInt("lifes", 10);
                playerLifes = 10;
            }
            else
            {
                PlayerPrefs.SetInt("lifes", 5);

                playerLifes = 5;
            }
            sceneStart = false;
        }
       
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = spriteDown; // set the sprite to spriteDown
        textLifes.text = TEXT_LIFES + playerLifes;
    }

    
    private void OnEnable()
    {
        
        StartCoroutine("ShieldVariate");
        canvasUI.worldCamera = gameObject.GetComponent<Camera>();
        transform.position = vehicle.transform.position;
        
        if (PlayerPrefs.HasKey("lifes"))
        {
            if (PlayerPrefs.GetInt("lifes") > 2)
                playerLifes = PlayerPrefs.GetInt("lifes") - 2;
            else
                playerLifes = 1;
        }
        
        textLifes.text = TEXT_LIFES + playerLifes;
    }
    private void OnDisable()
    {
        
        PlayerPrefs.SetInt("lifes", playerLifes+2);
    }
    // Update is called once per frame
    void Update()
    {
       
           
        if (!pauseCanvas.isActiveAndEnabled&&!inventory.activeSelf)
        {
            Move();
            shoot();
            GetInput();
            shield.transform.position = transform.position;
            
        }
        ToggleInventory();
    }


    public IEnumerator InvincibleVisual()
    {
        
            while (invincible)
            {
                coroutineIsLooping = true;
                rend.enabled = false;
                yield return new WaitForSeconds(0.1f);
                rend.enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
         
    }
    private void resetInvulnerability()
    {
        invincible = false;
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private IEnumerator ShieldVariate()
    {
        float variation = 0.1f;
        
        float interval = 0.5f;
  
        if (shield.activeSelf&& shieldBar.fillAmount > 0)
        {
            while (shield.activeSelf && shieldBar.fillAmount > 0)
            {
                shieldBar.fillAmount -= variation;
                yield return new WaitForSeconds(interval);
            }
        }
        else
        {

            if (!shield.activeSelf)
            {
                while (!shield.activeSelf)
                {
                    shieldBar.fillAmount += variation;
                    yield return new WaitForSeconds(interval);
                }
            }
            else
            {
                shieldSound.Stop();
                shield.SetActive(false);
                invincible = false;
            }
        }

        StartCoroutine("ShieldVariate");
    }

    private void GetInput()
    {
        
            if (Input.GetButtonDown("Escape"))
        {
            if (!pauseCanvas.gameObject.activeSelf)
            {

                pauseCanvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseCanvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (!pauseCanvas.isActiveAndEnabled)
           {
            if (Input.GetButtonDown("shield"))
            {
                if (!shield.activeSelf && shieldBar.fillAmount == 1)
                {
                    if (shieldBar.fillAmount > 0)
                    {
                        shieldSound.Play();
                        shield.SetActive(true);

                        invincible = true;
                    }
                }
                else
                {
                    shieldSound.Stop();
                    shield.SetActive(false);

                    invincible = false;
                }
            }

            if(!invincible&&!inventory.activeSelf)
            {
                if (Input.GetButtonDown("vehicle"))
                {
                    vehicle.SetActive(true);
                    gameObject.SetActive(false);

                }
            }
            direction = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                spriteRenderer.sprite = spriteUp;
                direction += Vector2.up;
                  isAtUp = true;
                isAtRight = false;
                isAtBottom = false;
                isAtLeft = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                spriteRenderer.sprite = spriteLeft;
                direction += Vector2.left;
                isAtUp = false;
                isAtRight = false;
                isAtBottom = false;
                isAtLeft = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                spriteRenderer.sprite = spriteDown;
                direction += Vector2.down;
                      isAtUp = false;
                isAtRight = false;
                isAtBottom = true;
                isAtLeft = false;
            }

            if (Input.GetKey(KeyCode.D))
            {

                spriteRenderer.sprite = spriteRight;
                direction += Vector2.right;
                  isAtRight = true;
                isAtUp = false;
                isAtBottom = false;
                isAtLeft = false;
            }
        }
    }

    public void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletSpawner.transform.position, gameObject.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawner.transform.right * speedBullet;
            Destroy(bullet, 3.0f);
        }
    }
     public static void SetSpeedBullet(float speed1)
    {
        speedBullet = speed1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyBullet")
        {
            if (!invincible && !shield.activeSelf)
            {
                PlayerDie();
                Invoke("resetInvulnerability", 1);
                invincible = true;
                StartCoroutine("InvincibleVisual");

            }
           
            Destroy(collision.gameObject);
        }
        if (collision.tag == "health")
        {
            PlayerHeal();
            Destroy(collision.gameObject);
        }
      
    }

    public void PlayerDie()
    {
        if (!invincible)
        {
            playerLifes--;
            if (playerLifes <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                textLifes.text = TEXT_LIFES + playerLifes;
            }
            PlayerPrefs.SetInt("lifes", playerLifes);
            
        }
       
    }

    public void PlayerHeal()
    {
        heartSound.Play();
        playerLifes++;
        textLifes.text = TEXT_LIFES + playerLifes;
        PlayerPrefs.SetInt("lifes", playerLifes);
    }
    public void ToggleInventory()
    {
        if (!inventory.activeSelf && Input.GetButtonDown("backButton"))
        {
            inventory.SetActive(true);
            Time.timeScale = 0;


        }
        else
        {
            if (Input.GetButtonDown("backButton"))
            {
                inventory.SetActive(false);
                Time.timeScale = 1;
            }
        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyMinon")
        {
            if (!invincible && !shield.activeSelf)
            {
                PlayerDie();
                Invoke("resetInvulnerability", 1);
                invincible = true;
                StartCoroutine("InvincibleVisual");

            }
        }
    }

    public static string GetDirection()
    {
        if (isAtBottom)
            return "bottom";
        if (isAtUp)
            return "up";
        if (isAtLeft)
            return "left";
        if (isAtRight)
            return "right";

        return "bottom";
    }
}
