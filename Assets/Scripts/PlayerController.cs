using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    Canvas canvasUI;
    [SerializeField]
    private float speed;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject bulletSpawner;
   
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
    void Start()
    {
        
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
       
            GetInput();
        if (!pauseCanvas.isActiveAndEnabled)
        {
            Move();
            shoot();
            ToggleInventory();
            shield.transform.position = transform.position;
        }
     }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private IEnumerator ShieldVariate()
    {
        float variation = 0.1f;
        
        float interval = 0.5f;
        float longInterval = 2f;
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
                    yield return new WaitForSeconds(longInterval);
                }
            }
            else
            {
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
                        shield.SetActive(true);

                        invincible = true;
                    }
                }
                else
                {
                    shield.SetActive(false);

                    invincible = false;
                }
            }

            if (Input.GetButtonDown("vehicle"))
            {
                vehicle.SetActive(true);
                gameObject.SetActive(false);

            }
            direction = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                spriteRenderer.sprite = spriteUp;
                direction += Vector2.up;

                bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 90);
                if (!isAtUp)
                    weapon.transform.rotation = Quaternion.Euler(0, 0, 180);
                if (isAtRight)
                    weapon.transform.position = new Vector3(weapon.transform.position.x - 0.20f, weapon.transform.position.y);
                isAtUp = true;
                isAtRight = false;
                isAtBottom = false;
                isAtLeft = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                spriteRenderer.sprite = spriteLeft;
                direction += Vector2.left;
                bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 180);
                if (!isAtLeft)
                    weapon.transform.rotation = Quaternion.Euler(0, 0, 270);
                if (isAtRight)
                    weapon.transform.position = new Vector3(weapon.transform.position.x - 0.20f, weapon.transform.position.y);
                isAtUp = false;
                isAtRight = false;
                isAtBottom = false;
                isAtLeft = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                spriteRenderer.sprite = spriteDown;
                direction += Vector2.down;
                bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 270);
                if (!isAtBottom)
                    weapon.transform.rotation = Quaternion.Euler(0, 0, 0);
                if (isAtRight)
                    weapon.transform.position = new Vector3(weapon.transform.position.x - 0.20f, weapon.transform.position.y);
                isAtUp = false;
                isAtRight = false;
                isAtBottom = true;
                isAtLeft = false;
            }

            if (Input.GetKey(KeyCode.D))
            {

                spriteRenderer.sprite = spriteRight;
                direction += Vector2.right;
                bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 0);
                if (!isAtRight)
                    weapon.transform.position = new Vector3(weapon.transform.position.x + 0.20f, weapon.transform.position.y);
                if (!isAtRight)
                    weapon.transform.rotation = Quaternion.Euler(0, 0, 90);
                isAtRight = true;
                isAtUp = false;
                isAtBottom = false;
                isAtLeft = false;
            }
        }
    }

    public void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, gameObject.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletPrefab.transform.right * 5.0f;
            Destroy(bullet, 2.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyBullet")
        {
            PlayerDie();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "health")
        {
            PlayerHeal();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "enemyMinon")
        {
            PlayerDie();
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
