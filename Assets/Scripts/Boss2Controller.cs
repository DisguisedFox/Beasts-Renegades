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
       
        StartCoroutine("Shoot");
        
    }
	
	// Update is called once per frame
	void Update () {
       
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
