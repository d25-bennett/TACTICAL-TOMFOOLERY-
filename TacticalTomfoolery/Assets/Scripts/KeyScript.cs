using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
	public GameObject key;
	private Collider col;
	private OVRGrabbable grab;

	public bool triggered;

	// Start is called before the first frame update
	void Start()
	{
		grab = GetComponent<OVRGrabbable>();
		//grab.enabled = false;
	}

	private void Update()
	{
		if (grab.isGrabbed && !triggered)
		{
			//Instantiate(key);
			Debug.Log("KEY MASTER");
			triggered = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		//.Log("Been hit");
		if (other.tag == "key")
		{
			// If book is colliding with key, ignore the collision
			Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
		}
	}
}
