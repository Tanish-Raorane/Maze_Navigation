using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CaneController : MonoBehaviour
{
    public GameObject senmagWorkspace;
    private GameObject defaultCursor;
    private GameObject deviceLocation;
    private bool firstTime = false;

    public GameObject canePrefab;
    private GameObject cane;

    public GameObject rightHandModel, leftHandModel;
    //public GameObject rightHandVisual;

    private Vector3 positionVelocity;
    public float positionSmoothTime = 0.05f;
    private bool isTriggerPressed = false;

    public InputActionReference rightTrigger, leftTrigger;
    public GameObject xrOrigin;
    private GameObject xrCamera;

    public float moveSpeed = 3;
    public float rotationSpeed = 60;
    

    //public GameObject rightHandDummy;

    private bool oneTime = false;  //Replace this with an Audio trigger in a coroutine once sound is added so that the user can draw the cane only after its' corresponding audio prompt is given

    void Start()
    {
        //StartCoroutine(CanePosition());
    }


    //public IEnumerator CanePosition()
    //{
    //    yield return new WaitUntil(() => firstTime);
    //   while(!isTriggerPressed)
    //    {
    //        senmagWorkspace.SetActive(false); 
    //        cane.transform.position = rightHandModel.transform.position;
    //    }




    //}

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
        //elses
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
            //cane.transform.SetParent(defaultCursor.transform.GetChild(5).transform);
            defaultCursor.GetComponent<Senmag_stylusControl>().currentToolTip = null;
            defaultCursor.GetComponent<Senmag_stylusControl>().currentToolTip = cane;
            //cane.transform.GetChild(0).position = rightHandModel.transform.position;
            //senmagWorkspace.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, 0);
            xrCamera = xrOrigin.transform.GetChild(0).GetChild(0).gameObject;
            //cane.transform.GetChild(0).transform.position = new Vector3(xrCamera.transform.position.x + 0.3f, xrCamera.transform.position.y - 0.2f, xrCamera.transform.position.z + 0.1f);

            //cane.transform.GetChild(0).transform.position = xrCamera.transform.position;

            /*Setting layer of cane*/
            cane.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Cane");


            firstTime = true;
        }


        /*code to make the position and rotation of the cursor same as the right hand model*/
        //cane.transform.GetChild(0).transform.position = rightHandModel.transform.position;
        //cane.transform.GetChild(0).transform.rotation = rightHandModel.transform.rotation;
        //cane.transform.rotation = rightHandModel.transform.rotation;
        //cane.transform.position = rightHandModel.transform.position;


        //defaultCursor.transform.rotation = rightHandModel.transform.rotation;
        //defaultCursor.transform.position = rightHandModel.transform.position;

        //deviceLocation.transform.rotation = rightHandModel.transform.rotation;
        //deviceLocation.transform.position = rightHandModel.transform.position;




        //cane.transform.GetChild(0).transform.rotation = Quaternion.Euler(rightHandModel.transform.rotation.x + 90f, rightHandModel.transform.rotation.y, rightHandModel.transform.rotation.z);
        //cane.transform.GetChild(0).transform.localEulerAngles = new Vector3(rightHandModel.transform.rotation.x + 90f, rightHandModel.transform.rotation.y, rightHandModel.transform.rotation.z);




        //Vector3 pointDirectionUp = (rightHandDummy.transform.position - cane.transform.GetChild(0).transform.position).normalized;
        //cane.transform.GetChild(0).transform.LookAt(pointDirectionUp);  

        //Vector3 currentForward = cane.transform.GetChild(0).transform.forward;



        /* code to make Cane point towards the right hand */

        //Vector3 pointDirectionUp = (rightHandModel.transform.position - cane.transform.GetChild(0).transform.position).normalized;

        //Vector3 refForward = cane.transform.forward;
        //if (Mathf.Abs(Vector3.Dot(pointDirectionUp, refForward)) > 0.99f)
        //    refForward = Vector3.right;


        //Vector3 forward = Vector3.Cross(pointDirectionUp, Vector3.Cross(refForward, pointDirectionUp)).normalized;



        //cane.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(forward, pointDirectionUp);




        //// Controller's forward vector
        //Vector3 forward = leftHandModel.transform.forward;

        //// Custom up vector (optional)
        //Vector3 up = leftHandModel.transform.up;

        //// Target rotation
        //Quaternion targetRotation = Quaternion.LookRotation(forward, up);

        //// Smooth rotation towards target (adjust rotationSpeed as needed)
        //float rotationSpeed = 10f; // higher = faster catch-up
        //cane.transform.GetChild(0).rotation = Quaternion.Slerp(
        //    cane.transform.GetChild(0).rotation,
        //    targetRotation,
        //    Time.deltaTime * rotationSpeed
        //);

        
        if (leftTrigger.action.WasPressedThisFrame() && !oneTime)
        {
            cane.transform.GetChild(0).transform.position = leftHandModel.transform.position + new Vector3(0.6f, 0, 0.6f);
            //cane.transform.GetChild(0).transform.position = new Vector3(rightHandModel.transform.position.x, rightHandModel.transform.position.y, rightHandModel.transform.position.z);
            //cane.transform.GetChild(0).transform.localPosition = new Vector3(cane.transform.GetChild(0).transform.localPosition.x, cane.transform.GetChild(0).transform.localPosition.y, cane.transform.GetChild(0).transform.localPosition.z + 0.26f);
            oneTime = true;
            //isTriggerPressed = !isTriggerPressed;

        }

            //if (isTriggerPressed)
            //{
            //    if (firstTime)
            //    {
            //        senmagWorkspace.SetActive(true);
            //    }

            //}

            //if (!isTriggerPressed)
            //{
            //    if (firstTime)
            //    {
            //        senmagWorkspace.SetActive(false);
            //    }

            //}

        if (defaultCursor.GetComponent<Senmag_stylusControl>().isColliding)
        {
            xrOrigin.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0;
            xrOrigin.GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed = 0;
        }
        else
        {
            xrOrigin.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = moveSpeed;
            xrOrigin.GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed = rotationSpeed;
        }

    }


    //private void LateUpdate()
    //{
    //    if (senmagWorkspace.transform.GetChild(0).GetChild(1) == null || senmagWorkspace.transform.childCount == 0)
    //    {
    //        return;
    //    }

    //    if (firstTime)
    //    {
    //        cane.transform.GetChild(0).transform.position = rightHandModel.transform.position;
    //        cane.transform.GetChild(0).transform.rotation = rightHandModel.transform.rotation;
    //    }
    //}

}
