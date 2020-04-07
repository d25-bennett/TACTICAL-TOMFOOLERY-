using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
	public EventManager events;
	private AudioSource audioSource;
	private OVRGrabbable grab;
	private bool pickedUp;

	private void Start()
	{
		grab = GetComponent<OVRGrabbable>();
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}

	// Update is called once per frame
	void Update()
    {
        if (grab.isGrabbed && !pickedUp)
		{
			pickedUp = true;
			audioSource.Stop();
			events.names = eventNames.phone;
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			events.names = eventNames.phone;
			Destroy(this);
		}
	}
}
