using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    public GameObject caneController;
    public Renderer planeRend;
    public OpenDoor doorOpener;
    public WeighingScale weighingScale;
    //private bool openDoor = false;
    public GameObject doorLeft, doorRight;

    private bool startFade = false;
    public float targetAlpha;
    private float fadeDuration = 7f;
    private float timer = 0f;

    void Start()
    {
        StartCoroutine(startSequence());
    }

    public IEnumerator startSequence()
    {

        //Intro Narration (Internal Monologue, Heavy Breaths)

        yield return new WaitForSecondsRealtime(4f);
        startFade = true;
        yield return new WaitForSecondsRealtime(7f);
        //caneController.SetActive(true);
        //Instruction : Point your Left Controller forward and press on the tirgger to spawn the cane
        //Instruction : Move the Joystick on the Left controller front and back to move forwards and backwards, left and right to rotate the rig anticlockwise and clockwise respectively
        yield return new WaitForSecondsRealtime(10f);
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




