using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossScript : MonoBehaviour {

    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float enemySpeed;
    private Vector3 positionInitial;
    [SerializeField]
    GameObject bulletPrefab;
    private int enemyLifes = 5;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform spawn;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite spriteSmoke;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(shooting());
    }

    IEnumerator shooting()
    {
        while (true)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletPrefab.transform.up * 7.0f;
            Destroy(bullet, 2.0f);
            yield return new WaitForSeconds(2.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerBullet")
        {
            EnemyDie();
            Destroy(collision.gameObject);
        }
    }

    public void EnemyDie()
    {
        enemyLifes--;
        if (enemyLifes <= 0)
        {
            spriteRenderer.sprite = spriteSmoke;
            Destroy(gameObject, 0.5f);
            //SceneManager.LoadScene("victory");
        }
    }
    private void FollowTarget()
    {
        if (Physics2D.OverlapCircle(transform.position, radius, layerMask))
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, layerMask);
            transform.position = Vector2.MoveTowards(transform.position, collider.transform.position, enemySpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        spawn.rotation = Quaternion.LookRotation(Vector3.forward, target.position - spawn.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
