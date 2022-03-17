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
}
