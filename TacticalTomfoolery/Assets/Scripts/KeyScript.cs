using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
	public GameObject key;
	public Collider col;
	public GameObject crosshair;
	private OVRGrabbable grab;

	public bool triggered;

	// Start is called before the first frame update
	void Start()
	{
		grab = GetComponent<OVRGrabbable>();
		grab.enabled = false;
		col.enabled = false;
		crosshair.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		//.Log("Been hit");
		if (other.tag == "Player" && !triggered)
		{
			GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
			Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
			gameObjectsRigidBody.mass = 5; // Set the GO's mass to 5 via the Rigidbody.
			grab.enabled = true;
			key.transform.parent = null;
			col.enabled = true;
			crosshair.SetActive(true);
			triggered = true;
		}
	}
}
