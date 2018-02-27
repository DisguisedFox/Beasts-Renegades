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
                invincible = true;
                if (spriteRenderer.sprite != spriteSmoke)
                {
                    Invoke("resetInvulnerability", 1);
                }
                else
                {
                    resetInvulnerability();
                }
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
        FollowTarget();
        spawn.rotation = Quaternion.LookRotation(Vector3.forward, target.position - spawn.position);
        StartCoroutine(InvincibleVisual());
    }

    public IEnumerator InvincibleVisual()
    {
        if (invincible && enemyLifes > 0)
        {
            while (invincible)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.1f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void EnemyDie()
    {
        enemyLifes--;
        if (enemyLifes <= 0)
        {
            spriteRenderer.sprite = spriteSmoke;
            if (isLastBoss)
            {
                lastTeleporter.SetActive(true);
            }
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void resetInvulnerability()
    {
        invincible = false;
    }

}
