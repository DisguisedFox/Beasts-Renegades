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
    SpriteRenderer weapon;
    [SerializeField]
    SpriteRenderer weapon2;
    [SerializeField]
    SpriteRenderer weapon3;
    [SerializeField]
    SpriteRenderer weapon4;

    [SerializeField]
    SpriteRenderer displayedWeaponRenderer;
    bool weaponChanged=false;
    // Use this for initialization
    void Start()
    {

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

                    displayedWeaponRenderer.sprite=weapon.sprite;
                    

                }
                if (slotBckgrnd2.color.Equals(Color.yellow))
                {
                    displayedWeaponRenderer.sprite = weapon2.sprite;
                    

                }
                if (slotBckgrnd3.color.Equals(Color.yellow))
                {
                    displayedWeaponRenderer.sprite = weapon3.sprite;

                }
                if (slotBckgrnd4.color.Equals(Color.yellow))
                {
                    displayedWeaponRenderer.sprite = weapon4.sprite;
                    
                }
                RotateWeapon();
            }
            weaponChanged = false;
        }
    }
    
    public void RotateWeapon()
    {
        if (Input.GetKey(KeyCode.W))
        {


            if (PlayerController.GetDirection().Equals("right"))
            {

                displayedWeaponRenderer.transform.position = new Vector3(displayedWeaponRenderer.transform.position.x - 0.20f, displayedWeaponRenderer.transform.position.y);

            }

            displayedWeaponRenderer.transform.rotation = Quaternion.Euler(0, 0, 90);
        }


        if (Input.GetKey(KeyCode.D))
        {


            if (!PlayerController.GetDirection().Equals("right"))
            {

                displayedWeaponRenderer.transform.position = new Vector3(displayedWeaponRenderer.transform.position.x + 0.20f, displayedWeaponRenderer.transform.position.y);

            }

            displayedWeaponRenderer.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {

            if (PlayerController.GetDirection().Equals("right"))
            {

                displayedWeaponRenderer.transform.position = new Vector3(displayedWeaponRenderer.transform.position.x - 0.20f, displayedWeaponRenderer.transform.position.y);

            }
            displayedWeaponRenderer.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (PlayerController.GetDirection().Equals("right"))
            {
                displayedWeaponRenderer.transform.position = new Vector3(displayedWeaponRenderer.transform.position.x - 0.20f, displayedWeaponRenderer.transform.position.y);

            }
            displayedWeaponRenderer.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
}
