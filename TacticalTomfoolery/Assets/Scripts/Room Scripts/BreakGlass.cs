using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
	public EventManager events;
	public GameObject brokenGlass;
	public bool window;
	private bool broken;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "bullet" && !broken)
		{
			Instantiate(brokenGlass, transform.position, transform.rotation);			
			Destroy(gameObject);
			broken = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "bullet" && !broken)
		{
			Instantiate(brokenGlass, transform.position, transform.rotation);
			Destroy(gameObject);
			broken = true;
		}
	}

}