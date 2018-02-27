using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VehicleController : MonoBehaviour {
    [SerializeField]
    GameObject player;
    [SerializeField]
    Canvas canvasUI;
    private float vehicleHalfSizeTopDown = 0.5f;
    private float vehicleHalfSize = 0.25f;
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

    private int playerLifes;
    [SerializeField]
    private Text textLifes;
    private const string TEXT_LIFES = "Lifes : ";

    [SerializeField]
    GameObject inventory;
    [SerializeField]
    Image shieldBar;
    [SerializeField]
    GameObject shield;
    static bool isAtRight = false;
    static bool isAtUp = false;
    static bool isAtBottom = true;
    static bool isAtLeft = false;
    
    // Use this for initialization
    [SerializeField]
    private SpriteRenderer weapon;
    // Use this for initialization
    void Start ()
    {

        StartCoroutine("ShieldVariate");

        canvasUI.worldCamera = GetComponent<Camera>();
        
        playerLifes = PlayerPrefs.GetInt("lifes");
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = spriteDown; // set the sprite to spriteDown
        textLifes.text = TEXT_LIFES + playerLifes;


    }

    // Update is called once per frame
    void Update ()
    {
        GetInput();
        Move();
        shoot();
        ToggleInventory();
        shield.transform.position = transform.position;
    }
    private void OnEnable()
    {
        transform.position = player.transform.position;
        
        bulletPrefab.SetActive(false);
        playerLifes = PlayerPrefs.GetInt("lifes");
        textLifes.text = TEXT_LIFES + playerLifes;
    }

   
    private void GetInput()
    {

        if(Input.GetButtonDown("vehicle"))
        {
            player.SetActive(true);
            gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("shield"))
        {
            if (!shield.activeSelf)
            {
                if (shieldBar.fillAmount > 0)
                {
                    shield.SetActive(true);

                    //RAJOUTER INVINCIBILITE
                }
            }
            else
            {
                shield.SetActive(false);

                //ENLEVER INVINCIBILITE

            }
        }
        
        direction = Vector2.zero;
      
        if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.sprite = spriteUp;
            direction += Vector2.left;

            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 90);
            if (!isAtUp)
            {
                weapon.transform.rotation = Quaternion.Euler(0, 0, 180);
                weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y+vehicleHalfSizeTopDown);
            }
            if (isAtBottom)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y + vehicleHalfSizeTopDown);

            }
            if (isAtLeft)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x + vehicleHalfSize, weapon.transform.position.y);

            }
            if (isAtRight)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x-vehicleHalfSize, weapon.transform.position.y);

            }
            if (isAtRight)
                weapon.transform.position = new Vector3(weapon.transform.position.x - vehicleHalfSize, weapon.transform.position.y);
            isAtUp = true;
            isAtRight = false;
            isAtBottom = false;
            isAtLeft = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.sprite = spriteLeft;
            direction += Vector2.down;
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 180);
            if (!isAtLeft)
            {
                weapon.transform.rotation = Quaternion.Euler(0, 0, 270);
                weapon.transform.position = new Vector3(weapon.transform.position.x -vehicleHalfSize, weapon.transform.position.y);

            }
            if (isAtBottom)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y + vehicleHalfSizeTopDown);

            }
            if (isAtRight)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x - vehicleHalfSize, weapon.transform.position.y);

            }
            if (isAtUp)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y - vehicleHalfSizeTopDown);

            }
             isAtUp = false;
            isAtRight = false;
            isAtBottom = false;
            isAtLeft = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            spriteRenderer.sprite = spriteDown;
            direction += Vector2.right;
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 270);
            if (!isAtBottom)
            {
                weapon.transform.rotation = Quaternion.Euler(0, 0, 0);
                weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y-vehicleHalfSizeTopDown);

            }
            if (isAtRight)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x-vehicleHalfSize, weapon.transform.position.y );

            }
            if (isAtLeft)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x + vehicleHalfSize, weapon.transform.position.y);

            }
            if (isAtUp)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y - vehicleHalfSizeTopDown);

            }
            isAtUp = false;
            isAtRight = false;
            isAtBottom = true;
            isAtLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {

            spriteRenderer.sprite = spriteRight;
            direction += Vector2.up;
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (!isAtRight)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x + vehicleHalfSize, weapon.transform.position.y);

            }
            if (isAtBottom)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x , weapon.transform.position.y+ vehicleHalfSizeTopDown);

            }
            if (isAtLeft)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x+vehicleHalfSize, weapon.transform.position.y );

            }
            if (isAtUp)
            {
                weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y - vehicleHalfSizeTopDown);

            }
            if (!isAtRight)
                weapon.transform.rotation = Quaternion.Euler(0, 0, 90);
            isAtRight = true;
            isAtUp = false;
            isAtBottom = false;
            isAtLeft = false;
        }
        bulletSpawner.transform.position = weapon.transform.position;
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
        if (shield.activeSelf && shieldBar.fillAmount > 0)
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
                //ENLEVER INVINCIBILITE
            }
        }

        StartCoroutine("ShieldVariate");
    }

    private void OnDisable()
    {
       
    }
    public void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
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

    public static string getDirection()
    {
        if (isAtBottom)
            return "bottom";
        if (isAtUp)
            return "up";
        if (isAtLeft)
            return "left";
        if (isAtBottom)
            return "right";

        return "bottom";
    }

}













