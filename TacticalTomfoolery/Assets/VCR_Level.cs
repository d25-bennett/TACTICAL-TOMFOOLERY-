using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VCR_Level : MonoBehaviour
{

	public int _levelLoaded;

	private void Start()
	{
		_levelLoaded = 1;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "vhsplayer")
		{
			SceneManager.LoadScene(_levelLoaded);
		}
	}
}
