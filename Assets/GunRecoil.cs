using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class GunRecoil : MonoBehaviour
{
    public GameObject senmagWorkspace;
    private Transform stylusCursor;
    private bool firstTime = false, oneTime = false;
    public GameObject recoilObject;
    public GameObject recoilObjectParent;
    //public GameObject gun;
    public InputActionReference rightTrigger;
    public InputActionReference leftTrigger;
    public Transform rightHand;

    //public Animator recoilAnim;
    private bool isRecoiling = false;

    private float moveSpeed = 2f;
    void Start()
    {
        
    }

    public IEnumerator RecoilRoutine()
    {
        isRecoiling = true;

        while (Vector3.Distance(recoilObject.transform.position, stylusCursor.GetChild(5).position) > 0.1f)
        {
            recoilObject.transform.position = Vector3.MoveTowards(recoilObject.transform.position, stylusCursor.GetChild(5).position, moveSpeed * Time.deltaTime);
            yield return null;
        }



        recoilObject.transform.localPosition = new Vector3 (0, 0, 0);
        isRecoiling = false;
        
    }
    
    void Update()
    {

        if(senmagWorkspace.transform.childCount == 0 || senmagWorkspace.transform.GetChild(0) == null)
            return;


        if(!firstTime)
        {
            stylusCursor = senmagWorkspace.transform.GetChild(0).GetChild(1);
            
            firstTime = true;
        }



        if (leftTrigger.action.WasPressedThisFrame() && !oneTime)
        {
            stylusCursor.GetChild(5).position = rightHand.position + new Vector3(0.3f, -0.25f, 0.4f);
            recoilObjectParent.transform.position = stylusCursor.GetChild(5).position + new Vector3(0f, 0f, 0.1f);
            //cane.transform.GetChild(0).transform.position = new Vector3(rightHandModel.transform.position.x, rightHandModel.transform.position.y, rightHandModel.transform.position.z);
            //cane.transform.GetChild(0).transform.localPosition = new Vector3(cane.transform.GetChild(0).transform.localPosition.x, cane.transform.GetChild(0).transform.localPosition.y, cane.transform.GetChild(0).transform.localPosition.z + 0.26f);
            oneTime = true;
            //isTriggerPressed = !isTriggerPressed;

        }


        

        if(rightTrigger.action.ReadValue<float>() > 0.1 && !isRecoiling)
        {
            recoilObjectParent.transform.position = stylusCursor.GetChild(5).position + new Vector3(0.1f, 0f, 0f);
            StartCoroutine(RecoilRoutine());
           


        }


    }
}
