using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float enemySpeed;
    [SerializeField]
    private GameObject lifePrefab;
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
            GameObject lifeHeart;
            float random = Mathf.Ceil(Random.value*2.0f);
            if (random == 1.0f)
            {
                lifeHeart = Instantiate(lifePrefab, lifePrefab.transform.position, lifePrefab.transform.rotation);
                lifeHeart.SetActive(true);
            }
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
}
