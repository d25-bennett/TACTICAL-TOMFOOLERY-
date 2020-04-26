﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
	public EventManager events;
	private AudioSource audioS;
	private OVRGrabbable grab;
	private bool pickedUp;

	private void Start()
	{
		grab = GetComponent<OVRGrabbable>();
		audioS = GetComponent<AudioSource>();
		CallStart();
	}

	// Update is called once per frame
	private void Update()
    {
        if (grab.isGrabbed && !pickedUp)
		{
			pickedUp = true;
			audioS.Stop();
			events.PickUpPhone();
		}
    }

	// Not used 
	//private void OnTriggerEnter(Collider other)
	//{
	//	if (other.tag == "Player")
	//	{
	//		events.SetEvent(EventNames.intro);
	//		Destroy(this);
	//	}
	//}

	public void CallStart()
	{
		audioS.PlayDelayed(4);
	}
}
