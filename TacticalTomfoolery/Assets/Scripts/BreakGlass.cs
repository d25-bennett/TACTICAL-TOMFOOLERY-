using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
	public GameObject brokenGlass;
	public float magnitudeCol, radius, power, upwards;
	public AudioClip smash;
	AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "bullet")
		{
			Destroy(gameObject);
			Instantiate(brokenGlass, transform.position, transform.rotation);
			audioSource.PlayOneShot(smash, 0.8f);
		}
	}
}