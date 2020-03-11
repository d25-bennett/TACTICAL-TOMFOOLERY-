using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGlass : MonoBehaviour
{
	float time;

    // Start is called before the first frame update
    void Start()
    {
		time = 3;
    }

    // Update is called once per frame
    void Update()
    {
		if (time <= 0)
		{
			Destroy(this);
		}
		else
		{
			time -= Time.deltaTime;
		}
    }
}
