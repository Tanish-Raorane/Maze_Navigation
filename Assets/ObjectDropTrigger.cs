using SenmagHaptic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)                                                         //entered when this object collides with another
    {
        if (other.gameObject.GetComponentInChildren<Senmag_interactionTools>() != null)                 //if the other object contains an interaction tools script
        {
            //other.gameObject.GetComponent<Senmag_interactionTools>().handleInteraction(Senmag_InteractionActionType.release, Senmag_StylusActionType.none);

            if (other.gameObject.GetComponentInChildren<Senmag_interactionTools>().pickedUp == true)    //if the other object is held by a cursor
            {
                Debug.Log("PickedUppppp");
                //other.gameObject.GetComponentInChildren<Senmag_interactionTools>().handleInteraction(Senmag_InteractionActionType.release, Senmag_StylusActionType.none);   //send the signal for the cursor to drop the other object
                
            }
        }
    }
}
