using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InventoryController1 : MonoBehaviour
{
    [SerializeField]
    Animator animatorBullet;
    [SerializeField]
    RuntimeAnimatorController animBullet1;
    [SerializeField]
    RuntimeAnimatorController animBullet2;
    [SerializeField]
    RuntimeAnimatorController animBullet3;
    [SerializeField]
    RuntimeAnimatorController animBullet4;
    [SerializeField]
    SpriteRenderer slotBckgrnd;
    [SerializeField]
    SpriteRenderer slotBckgrnd2;
    [SerializeField]
    SpriteRenderer slotBckgrnd3;
    [SerializeField]
    SpriteRenderer slotBckgrnd4;
 


    [SerializeField]
    SpriteRenderer weapon;
   

    [SerializeField]
    SpriteRenderer displayedWeaponRenderer;
    bool weaponChanged=false;
    // Use this for initialization
    void Start()
    {
        animBullet1 = (RuntimeAnimatorController)Resources.Load("Animations/bullet1");
        animBullet1 = (RuntimeAnimatorController)Resources.Load("Animations/bullet2");
        animBullet1 = (RuntimeAnimatorController)Resources.Load("Animations/bullet3");
        animBullet1 = (RuntimeAnimatorController)Resources.Load("Animations/bullet4");
        //modifiable selon les choix d'activation des armes
        slotBckgrnd2.gameObject.SetActive(true);
        slotBckgrnd3.gameObject.SetActive(true);
        slotBckgrnd4.gameObject.SetActive(true);
        slotBckgrnd.gameObject.SetActive(true);

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
            if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
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
                else
                {
                    if (!slotBckgrnd2.color.Equals(Color.white))
                    {

                        if (slotBckgrnd3.gameObject.activeSelf)
                        {
                            slotBckgrnd2.color = Color.white;
                            slotBckgrnd3.color = Color.yellow;
                        }
                    }
                    else
                    {
                        if (!slotBckgrnd3.color.Equals(Color.white))
                        {
                            if (slotBckgrnd4.gameObject.activeSelf)
                            {
                                slotBckgrnd3.color = Color.white;
                                slotBckgrnd4.color = Color.yellow;
                            }
                        }
                        else
                        {
                            if (!slotBckgrnd4.color.Equals(Color.white))
                            {
                                if (slotBckgrnd.gameObject.activeSelf)
                                {
                                    slotBckgrnd4.color = Color.white;
                                    slotBckgrnd.color = Color.yellow;
                                }
                            }
                        }
                    }
                }
            }
            else
            {

                if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
                {
                    weaponChanged = true;
                    if (!slotBckgrnd.color.Equals(Color.white))
                    {
                        if (slotBckgrnd4.gameObject.activeSelf)
                        {
                            slotBckgrnd.color = Color.white;
                            slotBckgrnd4.color = Color.yellow;
                        }
                    }
                    else
                    {
                        if (!slotBckgrnd2.color.Equals(Color.white))
                        {

                            if (slotBckgrnd.gameObject.activeSelf)
                            {
                                slotBckgrnd2.color = Color.white;
                                slotBckgrnd.color = Color.yellow;
                            }
                        }
                        else
                        {
                            if (!slotBckgrnd3.color.Equals(Color.white))
                            {
                                if (slotBckgrnd2.gameObject.activeSelf)
                                {
                                    slotBckgrnd3.color = Color.white;
                                    slotBckgrnd2.color = Color.yellow;
                                }
                            }
                            else
                            {
                                if (!slotBckgrnd4.color.Equals(Color.white))
                                {
                                    if (slotBckgrnd3.gameObject.activeSelf)
                                    {
                                        slotBckgrnd4.color = Color.white;
                                        slotBckgrnd3.color = Color.yellow;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    
                    if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
                    {
                        weaponChanged = true;
                        if (!slotBckgrnd.color.Equals(Color.white))
                        {
                            Debug.Log(12);
                            if (slotBckgrnd3.gameObject.activeSelf)
                            {
                                Debug.Log(13);
                                slotBckgrnd.color = Color.white;
                                slotBckgrnd3.color = Color.yellow;
                            }
                        }
                        else
                        {
                            if (!slotBckgrnd2.color.Equals(Color.white))
                            {

                                if (slotBckgrnd4.gameObject.activeSelf)
                                {
                                    slotBckgrnd2.color = Color.white;
                                    slotBckgrnd4.color = Color.yellow;
                                }
                            }
                            else
                            {
                                if (!slotBckgrnd3.color.Equals(Color.white))
                                {
                                    if (slotBckgrnd.gameObject.activeSelf)
                                    {
                                        slotBckgrnd3.color = Color.white;
                                        slotBckgrnd.color = Color.yellow;
                                    }
                                }
                                else
                                {
                                    if (!slotBckgrnd4.color.Equals(Color.white))
                                    {
                                        if (slotBckgrnd2.gameObject.activeSelf)
                                        {
                                            slotBckgrnd4.color = Color.white;
                                            slotBckgrnd2.color = Color.yellow;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else
                    {
                        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
                        {
                            weaponChanged = true;
                            if (!slotBckgrnd.color.Equals(Color.white))
                            {
                                if (slotBckgrnd3.gameObject.activeSelf)
                                {
                                    slotBckgrnd.color = Color.white;
                                    slotBckgrnd3.color = Color.yellow;
                                }
                            }
                            else
                            {
                                if (!slotBckgrnd2.color.Equals(Color.white))
                                {

                                    if (slotBckgrnd4.gameObject.activeSelf)
                                    {
                                        slotBckgrnd2.color = Color.white;
                                        slotBckgrnd4.color = Color.yellow;
                                    }
                                }
                                else
                                {
                                    if (!slotBckgrnd3.color.Equals(Color.white))
                                    {
                                        if (slotBckgrnd.gameObject.activeSelf)
                                        {
                                            slotBckgrnd3.color = Color.white;
                                            slotBckgrnd.color = Color.yellow;
                                        }
                                    }
                                    else
                                    {
                                        if (!slotBckgrnd4.color.Equals(Color.white))
                                        {
                                            if (slotBckgrnd2.gameObject.activeSelf)
                                            {
                                                slotBckgrnd4.color = Color.white;
                                                slotBckgrnd2.color = Color.yellow;
                                            }
                                        }
                                    }
                                }
                            }
                         }

                    }
                 }
             }
                    
                

            
            
           
            if (weaponChanged)
            {
                
                if (slotBckgrnd.color.Equals(Color.yellow))
                {

                    PlayerController.SetSpeedBullet(1f);
                    animatorBullet.runtimeAnimatorController = animBullet1;

                }
                if (slotBckgrnd2.color.Equals(Color.yellow))
                {
                   
                    PlayerController.SetSpeedBullet(3.5f);
                    animatorBullet.runtimeAnimatorController = animBullet2;
                }
                if (slotBckgrnd3.color.Equals(Color.yellow))
                {
                    
                    PlayerController.SetSpeedBullet(7f);
                    animatorBullet.runtimeAnimatorController = animBullet3;
                }
                if (slotBckgrnd4.color.Equals(Color.yellow))
                {
                  
                    PlayerController.SetSpeedBullet(15f);
                    animatorBullet.runtimeAnimatorController = animBullet4;
                }
                
            }
            weaponChanged = false;
        }
    }
    
   
}
