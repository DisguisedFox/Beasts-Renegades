using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    [SerializeField]
    private AudioSource dyingSound;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float enemySpeed;
    [SerializeField]
    private GameObject lifePrefab;
    private int enemyLifes = 2;
    float counter_time = 0.0f; 
    SpriteRenderer rend;
    bool lifeIsSpawned = false;
    enum state
    {
        IDLE,
        HURTED,
        DEAD
    }
    state enemy_state = state.IDLE;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
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
        enemy_state = state.HURTED;
        if (enemyLifes <= 0)
        {
            enemy_state = state.DEAD;
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
        
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    private void LateUpdate()
    {

        switch (enemy_state)
        {
            case state.IDLE:
                FollowTarget();
                break;
            case state.HURTED:
                counter_time += Time.deltaTime;
                if (counter_time <= 0.3f)
                {
                    rend.color = Color.red;
                }
                else
                {
                    rend.color = Color.white;
                    enemy_state = state.IDLE;
                    counter_time = 0.0f;
                }
                break;
            case state.DEAD:
             
                dyingSound.Play();
                GameObject lifeHeart;
                float random = Mathf.Ceil(Random.value * 2.0f);
                if (!lifeIsSpawned)
                {
                    if (random == 1.0f)
                    {
                        lifeHeart = Instantiate(lifePrefab, lifePrefab.transform.position, lifePrefab.transform.rotation);
                        lifeHeart.SetActive(true);
                        lifeIsSpawned = true;
                       
                    }
                }
               
                Destroy(gameObject, 0.1f);
                break;
            default:
                break;
        }

    }
}
