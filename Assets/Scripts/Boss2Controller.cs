using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss2Controller : MonoBehaviour {

    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform gun;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject teleporter4;
    [SerializeField]
    bool lastEnemy;
    private int enemyLifes = 5;
    bool ready = true;
   
	// Use this for initialization
	void Start ()
    {
        StartCoroutine("SetReady");
        StartCoroutine("Shoot");
        
    }
	
	// Update is called once per frame
	void Update () {
        if(ready)
        Teleport();
	}

    private IEnumerator Shoot()
    {
        Rigidbody2D rigid;
        float speedBullet = 3f;
        GameObject bullet1 = Instantiate(bullet, gun);
        bullet1.SetActive(true);
        rigid = bullet1.GetComponent<Rigidbody2D>();
        rigid.AddForce(gun.transform.right*speedBullet,ForceMode2D.Impulse);
        Destroy(bullet1, 3f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("Shoot");
    }
    private IEnumerator SetReady()
    {
        
        yield return new WaitForSeconds(2f);
        ready = true;
    }
    private void Teleport()
    {
        float diffX = Mathf.Abs(Mathf.Abs(transform.position.x)- Mathf.Abs(player.transform.position.x));
        float diffY = Mathf.Abs(Mathf.Abs(transform.position.y)- Mathf.Abs(player.transform.position.y));
        if (diffX < 0.0005f||diffY<0.0005f)
        { 
        float scaleMove = 1.5f;
        transform.position = player.transform.position - new Vector3(player.transform.right.x + scaleMove, player.transform.right.y + scaleMove);
            ready = false;
    }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("playerBullet"))
        {
            Destroy(collision.gameObject);
            EnemyDie();
        }
    }
    public void EnemyDie()
    {
        enemyLifes--;
        if (enemyLifes <= 0)
        {
            teleporter4.SetActive(true);
            Destroy(gameObject);
            if (lastEnemy)
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
}
