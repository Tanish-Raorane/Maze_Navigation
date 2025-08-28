using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenerTrigger : MonoBehaviour
{
    public bool enterTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        enterTrigger = true;
    }

}

