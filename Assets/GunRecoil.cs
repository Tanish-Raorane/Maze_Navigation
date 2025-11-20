using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using SenmagHaptic;

public class GunRecoil : MonoBehaviour
{
    public GameObject senmagWorkspace;
    private Senmag_HapticCursor senmagHapticCursor;
    private int forceIndex = -1;
    private float forceTimer = 0f;
    private Transform stylusCursor;
    private bool firstTime = false, recoil = false;
    public AudioSource gunAudio;
    //public GameObject gun;
    public InputActionReference rightTrigger;
    //public InputActionReference leftTrigger;
    //public Transform rightHand;

    //public Animator recoilAnim;
    private bool isRecoiling = false;


    public GameObject bullet;
    public Transform spawnPoint;
    private float bulletSpeed = 20f;

    private float moveSpeed = 2f;
    void Start()
    {

    }


    //public IEnumerator CustomForceHandler()
    //{
    //    forceIndex = senmagHapticCursor.requestCustomForce(gameObject);

    //    Vector3 force = new Vector3(0, 0.2f, 0);
    //    senmagHapticCursor.modifyCustomForce(forceIndex, force, gameObject);

    //    yield return new WaitForSeconds(0.01f);

    //    Vector3 downForce = new Vector3(0, -0.1f, 0);
    //    senmagHapticCursor.modifyCustomForce(forceIndex, downForce, gameObject);

    //    yield return new WaitForSecondsRealtime(0.01f);

    //    senmagHapticCursor.releaseCustomForce(forceIndex, gameObject);
       



    //}

    void Update()
    {

        if(senmagWorkspace.transform.childCount == 0 || senmagWorkspace.transform.GetChild(0) == null )
            return;


        if(!firstTime)
        {
            stylusCursor = senmagWorkspace.transform.GetChild(0).GetChild(1);
            senmagHapticCursor = senmagWorkspace.transform.GetChild(0).gameObject.GetComponent<Senmag_HapticCursor>();
            
            firstTime = true;
        }



        //if (leftTrigger.action.WasPressedThisFrame() && !oneTime)
        //{
        //    stylusCursor.GetChild(5).position = rightHand.position + new Vector3(0.3f, -0.25f, 0.4f);
        //    recoilObjectParent.transform.position = stylusCursor.GetChild(5).position + new Vector3(0f, 0f, 0.1f);
        //    //cane.transform.GetChild(0).transform.position = new Vector3(rightHandModel.transform.position.x, rightHandModel.transform.position.y, rightHandModel.transform.position.z);
        //    //cane.transform.GetChild(0).transform.localPosition = new Vector3(cane.transform.GetChild(0).transform.localPosition.x, cane.transform.GetChild(0).transform.localPosition.y, cane.transform.GetChild(0).transform.localPosition.z + 0.26f);
        //    oneTime = true;
        //    //isTriggerPressed = !isTriggerPressed;

        //}

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    recoil = true;
        //    gunAudio.Play();
        //}


        if (rightTrigger.action.WasPressedThisFrame())
        {
            recoil = true;
            gunAudio.Play();

            GameObject SpawnedBullet = Instantiate(bullet);
            SpawnedBullet.transform.position = spawnPoint.transform.position;
            SpawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
            Destroy(SpawnedBullet, 7);
        }



        //if(rightTrigger.action.ReadValue<float>() > 0.1 && !isRecoiling)
        //{
        //    recoilObjectParent.transform.position = stylusCursor.GetChild(5).position + new Vector3(0.1f, 0f, 0f);
        //    StartCoroutine(RecoilRoutine());



        //}


    }

    private void FixedUpdate()
    {
        if (recoil)
        {

            if(forceIndex == -1)
            {
                forceIndex = senmagHapticCursor.requestCustomForce(gameObject);
                forceTimer = 0f;
            }
            

            forceTimer += Time.fixedDeltaTime;

            if(forceTimer < 0.1f)
            {
                Vector3 force = new Vector3(0f, 1f, -0.5f);
                senmagHapticCursor.modifyCustomForce(forceIndex, force, gameObject);
            }

            else if(forceTimer < 0.2f)
            {
                Vector3 force = new Vector3(0f, -0.3f, 0.2f);
                senmagHapticCursor.modifyCustomForce(forceIndex, force, gameObject);
            }

            else
            {
                senmagHapticCursor.releaseCustomForce(forceIndex, gameObject);
                forceIndex = -1;
                recoil = false;
            }

        }
    }
}
