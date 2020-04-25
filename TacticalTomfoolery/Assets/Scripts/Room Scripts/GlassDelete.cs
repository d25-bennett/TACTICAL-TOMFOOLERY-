using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDelete : MonoBehaviour
{
	float time;

	// Start is called before the first frame update
	void Start()
	{
		time = 6;
		transform.parent = null;
	}

	// Update is called once per frame
	void Update()
	{
		if (time <= 0)
		{
			Destroy(gameObject);
		}
		else if (time > 0)
		{
			time -= Time.deltaTime;
		}
	}
}
