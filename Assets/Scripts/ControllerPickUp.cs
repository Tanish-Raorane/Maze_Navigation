using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerPickUp : MonoBehaviour
{
    public InputActionProperty rightGrab;

    
    void Update()
    {
        if(rightGrab.action.ReadValue<float>() > 0.1f)
        {
            Debug.Log("Hi");
        }
    }
}
