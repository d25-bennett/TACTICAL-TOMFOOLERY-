using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIfGrabbed : MonoBehaviour
{
    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
	public TitleFade fade;
	private bool grabbed;
	private bool shot;

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
            if (!shot)
            {
                StartCoroutine(fade.FadeTo(0, 0.5f, 0f));
				Destroy(fade, 1);
				shot = true;
            }
        }

		if (!grabbed)
		{
			ControllerSprite();
		}
	}

	void ControllerSprite()
	{
		if (ovrGrabbable.isGrabbed)
		{
			StartCoroutine(fade.FadeTo(1, 0.5f, 1));
			grabbed = true;
		}
	}

}