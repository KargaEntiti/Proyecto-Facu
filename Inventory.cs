using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //boleano para saber si esta activo o no
    private bool inventoryEnable;
    //referencia al inventory
    public GameObject inventory;
    //referencia a los slots
    private int allSlots;
    //cuales estan disponibles
    private int enabledSlots;
    //guardar los slots
    private GameObject[] slot;
    //referenica a el slotHolder
    public GameObject slotHolder;
    
    void Start()
    {
        //pregunta cuantos hijos tiene
        allSlots=slotHolder.transform.childCount;
        //se lo guarda en el array
        slot = new GameObject[allSlots];
        
        for (int i = 0; i < allSlots; i++)
        {
            slot[i]= slotHolder.transform.GetChild(i).gameObject; 
            //se crea un array de indice cero y lo guardamos dentro del array

            if (slot[i].GetComponent<Slot>().item == null)
            //slot vacio
            {
                slot[i].GetComponent<Slot>().empty=true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnable = !inventoryEnable;
        }
        if (inventoryEnable)
        {
            //activar el panel
            inventory.SetActive(true);
        } else 
        {
            //desactiva el panel
            inventory.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            //se guarda en un gameobject el objeto con el que colisionamos
            GameObject itemPickedUp = other.gameObject;
            //se instancia a nuestra clase
            Item item = itemPickedUp.GetComponent<Item>();
            //añadirlo a nuestro inventario
            AddItem(itemPickedUp,item.ID,item.type,item.description,item.icon);
        }
    }
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                //pasar item al slot
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                //el objeto se va a hacer hijo del slot
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();


                slot[i].GetComponent<Slot>().empty = false;
            }
            return;
        }
    }
}
