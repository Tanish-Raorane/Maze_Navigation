using SenmagHaptic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterStylus : MonoBehaviour
{
    private GameObject caneController;
    //private Senmag_Workspace senmagWorkspace;

    //private void Start()
    //{
    //    senmagWorkspace = GameObject.Find("SenmagWorkspace").GetComponent<Senmag_Workspace>();
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Obstacle")
    //    {
    //        senmagWorkspace.hapticStiffness = 0.2f;
    //        senmagWorkspace.hapticDamping = 0.2f;
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Obstacle")
    //    {
    //        senmagWorkspace.hapticStiffness = 0.5f;
    //        senmagWorkspace.hapticDamping = 0.1f;
    //    }


    //}


    private void Start()
    {
        caneController = GameObject.Find("CaneController");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Senmag_HapticCursor>())
        {
            Debug.Log("Stylus Hit");
            caneController.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Senmag_HapticCursor>())
        {
            caneController.SetActive(true);
        }


    }
}
