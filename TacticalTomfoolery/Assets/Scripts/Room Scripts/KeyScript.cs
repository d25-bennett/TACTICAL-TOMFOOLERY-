using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject deskDoor;
    private OVRGrabbable grab;
	public bool triggered;
    public EventManager events;

	// Start is called before the first frame update
	void Start()
	{
		grab = GetComponent<OVRGrabbable>();
        triggered = false;
	}

	private void Update()
	{
		if (grab.isGrabbed && !triggered)
		{
            triggered = true;
            StartCoroutine(ReleaseKey(1f));
            StartCoroutine(UnlockDoor(3f));
        }
	}

    private IEnumerator ReleaseKey(float waitTime)
    {
       
        GameObject childKey = transform.Find("Key").gameObject;
        yield return new WaitForSeconds(waitTime);
  
        childKey.transform.parent = null;
        childKey.SetActive(true);

        events.PickUpKey();
    }

    private IEnumerator UnlockDoor(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);

        Rigidbody deskDoorRigi = deskDoor.GetComponent<Rigidbody>();
        deskDoorRigi.freezeRotation = false;
        deskDoorRigi.AddForce(0, 0, -2, ForceMode.Impulse);
        events.UnlockedDraw();
    }
}
