using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

	public Transform SecondPivot;
	public Transform MinutePivot;
	public Transform HourPivot;
	public float time;

	// Update is called once per frame
	void Update()
	{
		time = Time.realtimeSinceStartup;
		SecondPivot.localEulerAngles = new Vector3(0, (Time.realtimeSinceStartup * 6), 0);
		MinutePivot.localEulerAngles = new Vector3(0, (Time.realtimeSinceStartup * 0.1f), 0);
		HourPivot.localEulerAngles = new Vector3(0, (Time.realtimeSinceStartup * 0.0085f), 0);
	}
}
