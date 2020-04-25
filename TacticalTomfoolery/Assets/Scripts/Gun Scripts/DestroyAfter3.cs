using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class DestroyAfter3 : MonoBehaviour 
 {
	private void Start()
	{
		Destroy(gameObject, 3);
	}
 }