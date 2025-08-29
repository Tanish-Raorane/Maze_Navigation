using SenmagHaptic;
using UnityEngine;

public class OnEnterDoor : MonoBehaviour
{
    

    public bool shouldOpen = false;
    private Transform door;
    public float openAngle = -75f;
    public float rotationSpeed = 50f;
    private AudioSource doorSound;
    private bool firstTime = false;


    void Start()
    {
        //door = transform.GetChild(0).GetChild(0);
        doorSound = GameObject.Find("DoorSound").GetComponent<AudioSource>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Senmag_HapticCursor>() || other.CompareTag("Door"))
        {
            
            if (!shouldOpen)
            {
                
               
                
                shouldOpen = true;

            }
        }
    }

    void Update()
    {
        if (shouldOpen)
        {
            Quaternion currentRotation = gameObject.transform.localRotation;
            Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
            gameObject.transform.localRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);

            if(!firstTime)
            {
                doorSound.Play();   
                firstTime = true;   
            }

        }
    }
}