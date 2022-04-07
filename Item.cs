using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    //identificación de los items
    public string type;
    //especifar si se puede agarrar o solo tomar
    public string description;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;

    [HideInInspector]
    public GameObject weaponManager;

    [HideInInspector]
    public GameObject weapon;

    public bool playerWeapon;

    private void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");
        if (!playerWeapon)
        {
            int allweapons = weaponManager.transform.childCount;
            //se fija el id y elimina uno para mostrar el otro
            for (int i = 0; i < allweapons; i++)
            {
                if(weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID==ID)
                {
                    //para establecer la igualdad de items
                    weapon=weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void Update()
    {
        if (equipped)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                equipped = false;
            }
            if (equipped == false)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ItemUsage()
    {
        if(type =="Weapon")
        {
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equipped = true;
        }
    }
}
