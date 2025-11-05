using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Sequence : MonoBehaviour
{
    public GameObject caneController;
    public Renderer planeRend;
    //public OpenDoor doorOpener;
    //public WeighingScale weighingScale;
    //private bool openDoor = false;
    //public GameObject doorLeft, doorRight;

    private bool startFade = false;
    public float targetAlpha;
    private float fadeDuration = 7f;
    private float timer = 0f;

    public AudioSource[] destinationAudio;

    public AudioSource wind;
    public AudioSource breaths;
    public AudioSource ND1;
    public AudioSource ND2;
    public AudioSource ND3;
    public AudioSource ND7;
    public AudioSource ND8;
    public AudioSource footsteps;
    public AudioSource footsteps2;
    public AudioSource carStart;
    //public AudioSource carStop;
    public AudioSource carDoor;
    public AudioSource chain;
    public AudioSource doorSlam;
    public GameObject leftController;
    public GameObject xrOrigin;


    public bool skip = false;


    //public bool orientCane = false;

    void Start()
    {
        caneController.SetActive(false);
        xrOrigin.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0;
        xrOrigin.GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed = 0;
        leftController.SetActive(false);
        for (int i = 0; i < destinationAudio.Length; i++)
        {
            destinationAudio[i].gameObject.SetActive(false);    
        }
       
        StartCoroutine(startSequence());
    }

    public IEnumerator startSequence()
    {

        if(!skip)
        {
            yield return new WaitForSecondsRealtime(1f);
            wind.Play();
            yield return new WaitForSecondsRealtime(1f);
            ND1.Play();
            yield return new WaitForSecondsRealtime(8f);
            ND2.Play();
            yield return new WaitForSecondsRealtime(9f);
            footsteps.Play();
            yield return new WaitForSecondsRealtime(7f);
            ND3.Play();
            yield return new WaitForSecondsRealtime(10f);
            breaths.Play();
            carStart.Play();
            yield return new WaitForSecondsRealtime(6f);
            carDoor.Play();
            yield return new WaitForSecondsRealtime(1.5f);
            ND7.Play();
            chain.Play();
            yield return new WaitForSecondsRealtime(12f);
            footsteps2.Play();
            yield return new WaitForSecondsRealtime(7f);
            doorSlam.Play();
        }
       
        yield return new WaitForSecondsRealtime(1f);
        startFade = true;
        for (int i = 0; i < destinationAudio.Length; i++)
        {
            destinationAudio[i].gameObject.SetActive(true);
        }
        ND8.Play();
        leftController.SetActive(true);
        caneController.SetActive(true);
        xrOrigin.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 3;
        xrOrigin.GetComponent<ActionBasedContinuousTurnProvider>().turnSpeed = 60;


        //yield return new WaitForSecondsRealtime(7f);
        //caneController.SetActive(true);
        //Instruction : Point your Left Controller forward and press on the tirgger to spawn the cane
        //Instruction : Move the Joystick on the Left controller front and back to move forwards and backwards, left and right to rotate the rig anticlockwise and clockwise respectively
        //yield return new WaitForSecondsRealtime(10f);
        //Internal Monologue : I need to hit the cane on the ground and on objects to make sense of my enviroment, where am I?
        //yield return new WaitUntil(() => doorOpener.enterTrigger);
        ////Internal Monologue : That door looks like its the way to the exit, but it seems locked
        //yield return new WaitForSecondsRealtime(2f);
        ////Internal Monologue : wait, whats this, is this some kind of a joke? 
        //yield return new WaitForSecondsRealtime(1f);
        ////Internal Monologue : Looks like I have to arrange the cubes according to their weight
        ////Instruction : Use the top button on the stylus to pick up objects
        ////yield return new WaitUntil(() => weighingScale.finished);
        ////doorLeft.GetComponent<OnEnterDoor>().shouldOpen = true;
        ////doorRight.GetComponent<OnEnterDoor>().shouldOpen = true;






    }

    void Update()
    {
        if (startFade)
        {
            if (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, targetAlpha, timer / fadeDuration);
                Color color = planeRend.material.color;
                color.a = alpha;
                planeRend.material.color = color;

            }

            else
            {
                startFade = false;
            }



        }
    }
}




