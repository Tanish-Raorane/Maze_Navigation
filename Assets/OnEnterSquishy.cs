using SenmagHaptic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterSquishy : MonoBehaviour
{
    private AudioSource bedSound;
    void Start()
    {
        bedSound = GameObject.Find("BedSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Senmag_HapticCursor>())
        {
            bedSound.Play();
        }
    }

    void Update()
    {
        
    }
}
