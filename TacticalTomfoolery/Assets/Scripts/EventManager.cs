using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eventNames
{
	none,
	phone,
	gun,
	glass,
	key,
	draw,
}

public class EventManager : MonoBehaviour
{
	public eventNames names;

	private AudioSource background;
	private AudioSource voice;
	public AudioClip phone;
	public AudioClip gun;
	public AudioClip glass;
	public AudioClip key;
	public AudioClip draw;

	private float timeLeft;

	// Start is called before the first frame update
	void Start()
	{
		names = eventNames.none;
		voice = GetComponent<AudioSource>();
		background = GetComponentInChildren<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (names != eventNames.none)
		{
			narrationSwitch();
		}
		if (timeLeft > 0)
		{
			background.volume = 0.1f;
		}
		else if (timeLeft <= 0)
		{
			background.volume = 0.2f;
		}
	}

	void narrationSwitch()
	{
		switch (names)
		{
			case eventNames.none:
				break;
			case eventNames.phone:
				narration(phone);
				break;
			case eventNames.gun:
				narration(gun);
				break;
			case eventNames.glass:
				narration(glass);
				break;
			case eventNames.key:
				narration(key);
				break;
			case eventNames.draw:
				narration(draw);
				break;
		}
	}

	void narration(AudioClip clip)
	{
		Debug.Log("Playing: " + clip.name);
		voice.PlayOneShot(clip);
		names = eventNames.none;
		timeLeft = clip.length;
	}
}
