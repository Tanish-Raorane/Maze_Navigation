using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool enterTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        enterTrigger = true;
    }
}
