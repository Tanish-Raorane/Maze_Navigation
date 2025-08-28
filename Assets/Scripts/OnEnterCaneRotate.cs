using SenmagHaptic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterCaneRotate : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponentInParent<Senmag_HapticCursor>())
        {
            other.transform.localEulerAngles = new Vector3(140f, 0f, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Senmag_HapticCursor>())
        {
            other.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
        }
    }

    void Update()
    {
        
    }
}
