using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    public AudioSource impactNoise;
    void Start()
    {
        impactNoise = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.relativeVelocity.magnitude > 2)
                impactNoise.Play();
    }
}