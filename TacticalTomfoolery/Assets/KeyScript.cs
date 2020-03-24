using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
	public GameObject key;
	public Collider col;
	public Rigidbody rb;
	public GameObject crosshair;

	private bool triggered;

	// Start is called before the first frame update
	void Start()
	{
		rb.useGravity = false;
		col.enabled = false;
		crosshair.SetActive(false);
	}

	private void Update()
	{
		key.transform.position = new Vector3 (key.transform.parent.position.x, (key.transform.parent.position.y + 0.0747999f), key.transform.parent.position.z);
		//key.transform.rotation = Quaternion.Euler(key.transform.parent.rotation.x,key.transform.parent.rotation.y + 90,key.transform.parent.rotation.z);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !triggered)
		{
			key.transform.parent = null;
			rb.useGravity = true;
			col.enabled = true;
			crosshair.SetActive(true);
			triggered = true;
		}
	}
}
