using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneController : MonoBehaviour
{
    public GameObject senmagWorkspace;
    private GameObject defaultCursor;
    private GameObject deviceLocation;
    private bool firstTime = false;

    public GameObject canePrefab;
    private GameObject cane;

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
            deviceLocation = senmagWorkspace.transform.GetChild(0).GetChild(0).gameObject;
            //defaultCursor.GetComponent<Senmag_stylusControl>().defaultTool = null;
            defaultCursor.GetComponent<Senmag_stylusControl>().defaultTool = canePrefab;

            defaultCursor.transform.GetChild(5).gameObject.SetActive(false);

            cane = Instantiate(canePrefab, new Vector3(defaultCursor.transform.GetChild(5).position.x, defaultCursor.transform.GetChild(5).position.y, defaultCursor.transform.GetChild(5).position.z), Quaternion.identity);
            cane.transform.SetParent(defaultCursor.transform);
            //defaultCursor.GetComponent<Senmag_stylusControl>().currentToolTip = null;
            defaultCursor.GetComponent<Senmag_stylusControl>().currentToolTip = cane;

            firstTime = true;
        }


        /*code to make the rotation of the cursor same as the right hand model*/
        cane.transform.GetChild(0).transform.rotation = rightHandModel.transform.rotation;



        cane.transform.GetChild(0).transform.position = rightHandModel.transform.position;

        //cane.transform.GetChild(0).transform.rotation = Quaternion.Euler(rightHandModel.transform.rotation.x + 90f, rightHandModel.transform.rotation.y, rightHandModel.transform.rotation.z);
        //cane.transform.GetChild(0).transform.localEulerAngles = new Vector3(rightHandModel.transform.rotation.x + 90f, rightHandModel.transform.rotation.y, rightHandModel.transform.rotation.z);




        //Vector3 pointDirectionUp = (rightHandDummy.transform.position - cane.transform.GetChild(0).transform.position).normalized;
        //cane.transform.GetChild(0).transform.LookAt(pointDirectionUp);  

        //Vector3 currentForward = cane.transform.GetChild(0).transform.forward;



        /* code to make Cane point towards the right hand */

        //Vector3 pointDirectionUp = (rightHandDummy.transform.position - cane.transform.GetChild(0).transform.position).normalized;

        //Vector3 refForward = cane.transform.forward;
        //if (Mathf.Abs(Vector3.Dot(pointDirectionUp, refForward)) > 0.99f)
        //    refForward = Vector3.right;


        //Vector3 forward = Vector3.Cross(pointDirectionUp, Vector3.Cross(refForward, pointDirectionUp)).normalized;



        //cane.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(forward, pointDirectionUp);
    }
}
