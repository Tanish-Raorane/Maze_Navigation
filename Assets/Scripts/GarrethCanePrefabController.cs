using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarrethCanePrefabController : MonoBehaviour
{
    public GameObject senmagWorkspace;
    private GameObject defaultCursor;
    private GameObject deviceLocation;
    private bool firstTime = false;

    private GameObject cylinder;
    private GameObject sphere;

    
    public GameObject rightHandModel;

    //public GameObject rightHandDummy;
    void Start()
    {

    }


    void Update()
    {

        if (senmagWorkspace.transform.GetChild(0).GetChild(1) == null || senmagWorkspace.transform.childCount == 0)
        {
            return;
        }

        //defaultCursor = senmagWorkspace.transform.GetChild(0).GetChild(0).gameObject;
        ////defaultCursor.GetComponent<Senmag_stylusControl>().defaultTool = null;
        //if(defaultCursor.GetComponent<Senmag_stylusControl>().defaultTool == null)
        //{
        //    Debug.Log("null");
        //}
        //else
        //{
        //    Debug.Log(" NOT null");
        //}


        if (!firstTime)
        {
            defaultCursor = senmagWorkspace.transform.GetChild(0).GetChild(1).gameObject;
            cylinder = defaultCursor.transform.GetChild(5).gameObject;
            sphere = defaultCursor.transform.GetChild(6).gameObject;
            sphere.transform.SetParent(cylinder.transform);

            firstTime = true;
        }

        cylinder.transform.position = rightHandModel.transform.position;
        cylinder.transform.rotation = rightHandModel.transform.rotation;

    }
}
