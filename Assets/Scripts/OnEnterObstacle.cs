using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterObstacle : MonoBehaviour
{
    private GameObject caneController;
    void Start()
    {
        caneController = GameObject.Find("CaneController"); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacled")
        {
            Debug.Log("Obstacle Hit");
            caneController.SetActive(false);    

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacled")
        {
            Debug.Log("Obstacle left");
            caneController.SetActive(true);

        }
    }
    void Update()
    {
        
    }
}
