using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFade : MonoBehaviour
{
	SpriteRenderer mat;

	private void Start()
	{
		mat = GetComponent<SpriteRenderer>();
		mat.material.color = new Color(0,0,0,0);
	}


	void Update()
	{
		//if (Input.GetKeyUp(KeyCode.T))
		//{
		//	StartCoroutine(FadeTo(0.0f, 1.0f));
		//}
		//if (Input.GetKeyUp(KeyCode.F))
		//{
		//	StartCoroutine(FadeTo(1.0f, 1.0f));
		//}
	}

	public IEnumerator FadeTo(float aValue, float aTime, float aWait)
	{
		yield return new WaitForSeconds(aWait);
		float alpha = mat.material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
			mat.material.color = newColor;
			yield return null;
		}
	}
}
