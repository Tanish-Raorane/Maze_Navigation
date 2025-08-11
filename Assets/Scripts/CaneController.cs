using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneController : MonoBehaviour
{
    public GameObject senmagWorkspace;
    private GameObject stylusCursor;
    private bool firstTime = false;


    void Start()
    {

    }


    void Update()
    {

        if (senmagWorkspace.transform.GetChild(0).GetChild(0) == null || senmagWorkspace.transform.childCount == 0)
        {
            return;
        }

        if (!firstTime)
        {
            stylusCursor = senmagWorkspace.transform.GetChild(0).GetChild(0).gameObject;
            firstTime = true;
        }

    }
}
