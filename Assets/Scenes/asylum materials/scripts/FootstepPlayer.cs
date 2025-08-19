using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This line ensures the script can't be added to an object
// without a CharacterController, which we need.
[RequireComponent(typeof(CharacterController))]
public class FootstepPlayer : MonoBehaviour
{
    // This is a public variable that will hold our Wwise Event.
    // We can drag and drop our footstep event here in the Unity Inspector.
    public AK.Wwise.Event FootstepEvent;

    // This controls how far we have to move before a footstep sound plays.
    // A value of 1.8 is a good starting point for a walking pace.
    public float StepDistance = 1.8f;

    // These are private variables for the script to use.
    private CharacterController characterController;
    private float distanceTraveled = 0f;

    // Start is called once when the game begins.
    void Start()
    {
        // Get the CharacterController component attached to this same GameObject.
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once every frame.
    void Update()
    {
        // First, check if the character is on the ground.
        // Then, check the character's horizontal speed (we ignore jumping/falling).
        // If the speed is greater than a tiny amount (to avoid playing sounds when standing still),
        // we start tracking the distance.
        if (characterController.isGrounded && GetHorizontalVelocity() > 0.1f)
        {
            // Add the distance moved in this frame to our counter.
            distanceTraveled += Vector3.ProjectOnPlane(characterController.velocity, Vector3.up).magnitude * Time.deltaTime;

            // If the distance we've traveled is greater than or equal to our StepDistance...
            if (distanceTraveled >= StepDistance)
            {
                // ...it's time to play a footstep sound!
                PlayFootstepSound();

                // Reset our distance counter back to zero to start tracking for the next step.
                distanceTraveled = 0f;
            }
        }
    }

    private void PlayFootstepSound()
    {
        // This is the line that tells Wwise to play our sound.
        // "Post" means to play the event. We pass "gameObject" so Wwise
        // knows the sound is coming from this specific object (our XR Rig).
        FootstepEvent.Post(gameObject);
    }

    // This is a helper function to get only the horizontal speed.
    private float GetHorizontalVelocity()
    {
        Vector3 velocity = characterController.velocity;
        velocity.y = 0; // Set the vertical part of the velocity to zero.
        return velocity.magnitude; // Return the length (speed) of the remaining vector.
    }
}
