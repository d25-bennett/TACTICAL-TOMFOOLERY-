using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public Transform slot;
	public PaperSystem sys;
	public bool morsePuzzle;
	private bool pickedUp;
	private OVRGrabbable ovrGrabbable;

    private void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }


    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Hit");
        if (other.tag == "clipboard")
        {
            transform.position = slot.transform.position;
            transform.rotation = slot.transform.rotation;
            gameObject.GetComponent<OVRGrabbable>().enabled = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            this.transform.parent.GetComponent<PaperSystem>().PaperPlaced();
        }
    }

	private void Update()
	{
		if (ovrGrabbable.isGrabbed && !pickedUp && morsePuzzle)
		{
			sys.MorsePaper();
		}
	}

}
