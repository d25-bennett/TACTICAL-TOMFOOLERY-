using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
	public EventManager events;
	public GameObject brokenGlass;
	public bool window;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "bullet")
		{
			Instantiate(brokenGlass, transform.position, transform.rotation);			
			Destroy(gameObject);
			TypeBroken();
		}
	}

	void TypeBroken()
	{
		if (window)
		{
			events.WindowBreak();
		}
		else
		{
			events.GlassBreak();
		}
	}

}