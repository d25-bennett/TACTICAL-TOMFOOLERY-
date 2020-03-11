using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
	public GameObject brokenGlass;
	public float magnitudeCol, radius, power, upwards;

	public AudioSource audioData;

	private void Start()
	{
		audioData = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude > magnitudeCol)
		{
			Destroy(gameObject);
			Instantiate(brokenGlass, transform.position, transform.rotation);
			audioData.Play(0);
			//brokenGlass.localScale = transform.position;
			//Vector3 explosionPos = transform.position;
			//Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

			//foreach (Collider hit in colliders)
			//{
			//	if (hit.GetComponent<Rigidbody>())
			//	{
			//		hit.GetComponent<Rigidbody>().AddExplosionForce(power * collision.relativeVelocity.magnitude, explosionPos, radius);
			//	}
			//}
		}
	}
}
