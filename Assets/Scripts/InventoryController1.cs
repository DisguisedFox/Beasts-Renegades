using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InventoryController1 : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer slotBckgrnd;
    [SerializeField]
    SpriteRenderer slotBckgrnd2;
    [SerializeField]
    SpriteRenderer slotBckgrnd3;
    [SerializeField]
    SpriteRenderer slotBckgrnd4;


   
    
    [SerializeField]
    GameObject weapon2;
    [SerializeField]
    GameObject weapon3;
    [SerializeField]
    GameObject weapon4;

    bool weaponChanged=false;
    // Use this for initialization
    void Start()
    {
        

        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("planete1")))
        {
            slotBckgrnd2.gameObject.SetActive(false);
            slotBckgrnd3.gameObject.SetActive(false);
            slotBckgrnd4.gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("planete2")))
        {
            slotBckgrnd2.gameObject.SetActive(true);
            slotBckgrnd3.gameObject.SetActive(false);
            slotBckgrnd4.gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("planete3")))
        {
            slotBckgrnd2.gameObject.SetActive(true);
            slotBckgrnd3.gameObject.SetActive(true);
            slotBckgrnd4.gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("planete4")))
        {
            slotBckgrnd2.gameObject.SetActive(true);
            slotBckgrnd3.gameObject.SetActive(true);
            slotBckgrnd4.gameObject.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        selectWeapon();

    }
    
    public void selectWeapon()
    {
        if (gameObject.activeSelf)
        {
            if (Input.GetAxisRaw("Horizontal")>0)
            {
                weaponChanged = true;
                if (!slotBckgrnd.color.Equals(Color.white))
                {
                    if (slotBckgrnd2.gameObject.activeSelf)
                    {
                        slotBckgrnd.color = Color.white;
                        slotBckgrnd2.color = Color.yellow;
                    }
                }
                if (!slotBckgrnd2.color.Equals(Color.white))
                {

                    if (slotBckgrnd3.gameObject.activeSelf)
                    {
                        slotBckgrnd2.color = Color.white;
                        slotBckgrnd3.color = Color.yellow;
                    }
                }
                if (!slotBckgrnd3.color.Equals(Color.white))
                {
                    if (slotBckgrnd4.gameObject.activeSelf)
                    {
                        slotBckgrnd3.color = Color.white;
                        slotBckgrnd4.color = Color.yellow;
                    }
                }
                if (!slotBckgrnd4.color.Equals(Color.white))
                {
                    if (slotBckgrnd.gameObject.activeSelf)
                    {
                        slotBckgrnd4.color = Color.white;
                        slotBckgrnd.color = Color.yellow;
                    }
                }
            }
           
            if (weaponChanged)
            {
                
                if (slotBckgrnd.color.Equals(Color.yellow))
                {
                   
                    weapon2.SetActive(false);
                    weapon3.SetActive(false);
                    weapon4.SetActive(false);

                }
                if (slotBckgrnd2.color.Equals(Color.yellow))
                {
                    weapon2.SetActive(true);
                    weapon3.SetActive(false);
                    weapon4.SetActive(false);
                }
                if (slotBckgrnd3.color.Equals(Color.yellow))
                {
                    weapon2.SetActive(false);
                    weapon3.SetActive(true);
                    weapon4.SetActive(false);
                }
                if (slotBckgrnd4.color.Equals(Color.yellow))
                {
                    weapon2.SetActive(false);
                    weapon3.SetActive(false);
                    weapon4.SetActive(true);
                }
               
            }
            weaponChanged = false;
        }
    }
    
    
}
