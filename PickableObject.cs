using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool isPickable = true;

    private void OnTriggerEnter(Collider other){ //cuando entra al trigger
        if(other.tag == "PlayerInteractionZone"){       //si el tag es el nombrado
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;//el componente se emparenta con el jugador
        }

    }

    private void OnTriggerExit(Collider other){//al salir del trigger
        if(other.tag == "PlayerInteractionZone"){
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null; //el componente se desparenta
        }

    }
}
