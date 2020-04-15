using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eventNames
{
	none, phone, gun, glass,
	key, draw, vhs,
}

public class EventManager : MonoBehaviour
{
	private eventNames _names;

	private AudioSource background;
	private AudioSource voice;
	public AudioClip phone;
	public AudioClip gun;
	public AudioClip glass;
	public AudioClip key;
	public AudioClip draw;

	private float timeLeft;

	private float start = 3f;
	public TitleFade _fade;
	public Phone _phone;


	// Start is called before the first frame update
	void Start()
	{
		_names = eventNames.none;
		voice = GetComponent<AudioSource>();
		background = GetComponentInChildren<AudioSource>();
		StartCoroutine(GameStart());
	}

	public void setEvent(eventNames names)
	{
		_names = names;
	}

	// Update is called once per frame
	void Update()
	{
		if (_names != eventNames.none)
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

	IEnumerator GameStart()
	{
		yield return new WaitForSeconds(2);
		StartCoroutine(_fade.FadeTo(1.0f, 1.0f));
		yield return new WaitForSeconds(5);
		StartCoroutine(_fade.FadeTo(0f, 1.0f));

	}

	void narrationSwitch()
	{
		switch (_names)
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
		_names = eventNames.none;
		timeLeft = clip.length;
	}
}
