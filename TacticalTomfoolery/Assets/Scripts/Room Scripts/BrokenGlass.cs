using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGlass : MonoBehaviour
{
	float time;
	public AudioClip smash;
	AudioSource audioSource;

	// Start is called before the first frame update
	void Start()
    {
		time = 3;
		audioSource = GetComponent<AudioSource>();
		audioSource.PlayOneShot(smash, 0.8f);
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
