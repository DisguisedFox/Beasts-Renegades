using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniBossScript : MonoBehaviour
{
    [SerializeField]
    private GameObject lastTeleporter;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float enemySpeed;
    private Vector3 positionInitial;
    [SerializeField]
    GameObject bulletPrefab;
    private int enemyLifes = 4;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform spawn;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite spriteSmoke;
    private bool invincible = false;
    [SerializeField]
    GameObject playerTempTarget;
    [SerializeField]
    GameObject vehicleTarget;
    [SerializeField]
    private bool isLastBoss;
    [SerializeField]
    private AudioSource deamonDying;

    enum state
    {
        IDLE,
        HURTED,
        INVICIBLE,
        DEAD
    }
    state boss_state = state.IDLE;

    float counter_time = 0.0f;
    float counter_turn = 0;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(shooting());
    }

    IEnumerator shooting()
    {
        while (enemyLifes > 0)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletPrefab.transform.up * 5.0f;
            Destroy(bullet, 0.4f);
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerBullet")
        {
            if (!invincible)
            {
                EnemyDie();
            }
            Destroy(collision.gameObject);
        }
    }

    private void FollowTarget()
    {
        if (Physics2D.OverlapCircle(transform.position, radius, layerMask) && enemyLifes > 0)
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, layerMask);
            transform.position = Vector2.MoveTowards(transform.position, collider.transform.position, enemySpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerTempTarget.activeSelf)
            target = vehicleTarget.transform;
        else
            target = playerTempTarget.transform;

        spawn.rotation = Quaternion.LookRotation(Vector3.forward, target.position - spawn.position);
        switch (boss_state)
        {
            case state.IDLE:
                FollowTarget();
                break;
            case state.HURTED:
                counter_time += Time.deltaTime;
                if (counter_time <= 0.3f)
                {
                    spriteRenderer.color = Color.red;
                }
                else
                {
                    spriteRenderer.color = Color.white;
                    boss_state = state.INVICIBLE;
                    counter_time = 0.0f;
                }
                break;
            case state.INVICIBLE:
                counter_time += Time.deltaTime;
                if (counter_turn <= 5)
                {
                    if (counter_time <= 0.1f)
                    {
                        spriteRenderer.enabled = false;
                    }
                    else
                    {
                        spriteRenderer.enabled = true;
                        if (counter_time <= 0.2f)
                        {
                            counter_time = 0.0f;
                            counter_turn++;
                        }
                    }
                }
                else
                {
                    spriteRenderer.enabled = true;
                    invincible = false;
                    counter_time = 0.0f;
                    counter_turn = 0;
                    boss_state = state.IDLE; 
                }
                break;
            case state.DEAD:
                spriteRenderer.sprite = spriteSmoke;
                deamonDying.Play();
                if (isLastBoss)
                {
                    lastTeleporter.SetActive(true);
                }
                Destroy(gameObject, 0.3f);
                break;
            default:
                break;
        }
    }

    public void EnemyDie()
    {
        enemyLifes--;
        invincible = true;
        boss_state = state.HURTED;
        if (enemyLifes <= 0)
        {
            boss_state = state.DEAD;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
