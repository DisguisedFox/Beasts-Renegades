using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


<<<<<<< HEAD
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float enemySpeed;
    private int enemyLifes = 3;


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
            Destroy(gameObject);
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
=======


    private Vector3 positionInitial;
    [SerializeField]
    GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
        StartCoroutine(shooting());
    }

    IEnumerator shooting()
    {
        while (true)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletPrefab.transform.right * 4.0f;
            Destroy(bullet, 3.0f);
            yield return new WaitForSeconds(3.0f);
        }


    }
    // Update is called once per frame
    void Update () {
		
	}
>>>>>>> origin/Fernand
}
