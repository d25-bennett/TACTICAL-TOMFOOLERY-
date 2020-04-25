using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCR_Level : MonoBehaviour
{
	private Animator anim;
	public EventManager events;
	private bool isPlaying;

	private void Start()
	{
		anim = transform.parent.parent.GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "vhsplayer" && !isPlaying)
		{
			events.SetEvent(EventNames.vhs);
			anim.SetBool("playAnim", true);
			Destroy(other.gameObject);
			StartCoroutine(WaitTime());
			isPlaying = true;
		}
	}

	// Maybe later on set up a check to what VHS is being inserted and then play different videos
	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds(5);
		events.TurnOnTV();
	}
}
