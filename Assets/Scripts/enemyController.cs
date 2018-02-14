using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemyController : MonoBehaviour {

    [SerializeField]
    AnimationCurve animationVibro;
    private float vibrateAmplificator = 2.0f;
    private float timeMax = 10.0f;
    private Vector3 positionInitial;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    [Range(1.0f,10.0f)]
    int ennemyLifes = 1;
    // Use this for initialization
    void Start () {
       
        positionInitial = transform.position;
        StartCoroutine(shooting());
    }
	
    IEnumerator shooting()
    {
        while (true)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000.0f, 0.0f));
            Destroy(bullet, 3.0f);
            yield return new WaitForSeconds(10.0f);
        }
       
        
    }
	// Update is called once per frame
	void Update () {

        if (tag.Equals("Boss"))
        {
            float currentTime = Time.timeSinceLevelLoad % timeMax;
            currentTime /= timeMax - 1;
            float positionY = animationVibro.Evaluate(currentTime);
            positionY *= vibrateAmplificator;
            Vector3 newPosition = new Vector3(positionInitial.x, positionY + positionInitial.y, positionInitial.z);
            transform.SetPositionAndRotation(newPosition, transform.rotation);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("bullet"))
        {

            ennemyLifes--;
         
            if(ennemyLifes<=0)
            {
                Destroy(gameObject);
                if(tag.Equals("Boss"))
                SceneManager.LoadScene("Victory");

            }
           

        }
    }
}
