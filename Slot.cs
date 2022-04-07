using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    
    public bool empty;
    public Sprite icon;

    public Transform slotIconGameObject;

    private void Start()
    {
        //el primer hijo de nuestro objeto
        slotIconGameObject = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        //actualiza el icono del slot
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
    }
}
