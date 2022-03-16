using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;

    void Update()
    {
        //si el objeto se puede agarrar
        if(ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            //y se apreto la f
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickUp; 
                //objeto agarrado igual al objeto a agarrar
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                //el objeto que se agarra ya no se puede volver a agarrar
                PickedObject.transform.SetParent(interactionZone);
                //setear padre
                PickedObject.transform.position=interactionZone.position;
                //misma posicion que la caja
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                //sin fisicas
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                //ya no le afecte fisicas en el body
            }
        }
        else if (PickedObject != null)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                //el objeto que se agarra se puede volver a agarrar
                PickedObject.transform.SetParent(null);
                //sacar padre
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                //activar fisicas
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                //afecte fisicas del entrono
                PickedObject = null;
                //ya nada 

            }
        }
    }
}
