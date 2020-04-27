using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIfGrabbed : MonoBehaviour
{
    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
	public TitleFade fade;
	private bool triggered;

    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()))
        {
            simpleShoot.TriggerShoot();
        }

		if (!triggered)
		{
			ControllerSprite();
		}
	}

	void ControllerSprite()
	{
		if (ovrGrabbable.isGrabbed)
		{
			StartCoroutine(fade.FadeTo(1, 0.5f, 1));
		}
		else if (!ovrGrabbable.isGrabbed)
		{
			StartCoroutine(fade.FadeTo(0, 0.5f, 0));
		}
		else if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()))
		{
			StartCoroutine(fade.FadeTo(0, 0.5f, 0.5f));
			triggered = true;
		}
	}

}