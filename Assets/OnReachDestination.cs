using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnReachDestination : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject xrOrigin;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        xrOrigin.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0;
        xrOrigin.GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed = 0;

        endScreen.SetActive(true);
    }

    void Update()
    {
        
    }
}
