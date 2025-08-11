using SenmagHaptic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollide : MonoBehaviour
{
    public GameObject senmagWorkspace;
    
    void Start()
    {

    }


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            senmagWorkspace.GetComponent<Senmag_Workspace>().updateCursorForces(0);
        }
    }
}
