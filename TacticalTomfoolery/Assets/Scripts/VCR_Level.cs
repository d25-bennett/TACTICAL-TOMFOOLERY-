using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCR_Level : MonoBehaviour
{
	public EventManager events;
	private bool isPlaying;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "vhsplayer" && !isPlaying)
		{
			events.setEvent(eventNames.vhs);
			transform.parent.parent.GetComponent<Animator>().SetBool("playAnim", true);
			Destroy(other.gameObject);
		}
	}
}
