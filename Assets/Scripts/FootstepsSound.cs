using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FootstepsSound : MonoBehaviour
{
    [Header("Footstep Settings")]
    public AudioSource footstepAudio;

    [Header("Input Action References")]
    public InputActionReference leftMoveAction; // XRI LeftHand/Move

    [Header("Movement Threshold")]
    public float moveThreshold = 0.1f; // Minimum joystick input to trigger footsteps

    private void OnEnable()
    {
        leftMoveAction.action.Enable();
    }

    private void OnDisable()
    {
        leftMoveAction.action.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = leftMoveAction.action.ReadValue<Vector2>();
        float forwardInput = moveInput.y;

        // If joystick is pushed forward/back beyond threshold
        if (Mathf.Abs(forwardInput) > moveThreshold)
        {
            if (!footstepAudio.isPlaying)
                footstepAudio.UnPause(); // Resume from paused position
        }
        else
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Pause(); // Pause playback
        }
    }
}
