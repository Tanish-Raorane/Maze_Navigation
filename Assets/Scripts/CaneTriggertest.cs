using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneTriggertest : MonoBehaviour
{
    
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hi");
    }

    void Update()
    {
        
    }
}
