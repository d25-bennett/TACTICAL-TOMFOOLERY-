using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

	public Transform SecondPivot;
	public Transform MinutePivot;
	public Transform HourPivot;


	public bool reversed; // Reverse if clock is going the wrong way 
	private float offset; // Not working right now

	// Update is called once per frame
	void Update()
	{
		System.DateTime currentTime = System.DateTime.Now;

		if (!reversed)
		{
			SecondPivot.eulerAngles = new Vector3(0, 0, (-Time.realtimeSinceStartup * 6) + offset);
			MinutePivot.eulerAngles = new Vector3(0, 0, (-Time.realtimeSinceStartup * 0.1f) + offset);
			HourPivot.eulerAngles = new Vector3(0, 0, (-Time.realtimeSinceStartup * 0.0085f) + offset);
		}
		else
		{
			SecondPivot.eulerAngles = new Vector3(0, 0, Time.realtimeSinceStartup * 6);
			MinutePivot.eulerAngles = new Vector3(0, 0, Time.realtimeSinceStartup * 0.1f);
			HourPivot.eulerAngles = new Vector3(0, 0, Time.realtimeSinceStartup * 0.0085f);
		}
    }
}
