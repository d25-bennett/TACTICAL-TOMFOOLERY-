using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventNames
{
	none, phone, gun, glass,
	key, draw, vhs,
}

public class EventManager : MonoBehaviour
{
	private EventNames _names;

	#region Audio 
	// Audio sources
	private AudioSource background;
	private AudioSource voice;
	// Audio for voice clips
	public AudioClip phone;
	public AudioClip gun;
	public AudioClip glass;

	public AudioClip key;
	public AudioClip draw;
	public AudioClip vhs;
	#endregion

	private float voiceTimeLeft;

	private float start = 3f;
	public TitleFade _fade;
	public Phone _phone;
	public GameObject VHS;

	// Selects volume of ambience
	private float bgVoice = 0.1f;
	private float bgNoVoice = 0.2f;
	private bool windowBroke;
	private bool glassBroke;


	// Start is called before the first frame update
	void Start()
	{
		_names = EventNames.none;
		voice = GetComponent<AudioSource>();
		background = GetComponentInChildren<AudioSource>();
		StartCoroutine(GameStart());
	}
	
	// Update is called once per frame
	void Update()
	{
		if (_names != EventNames.none)
		{
			NarrationSwitch();
		}
		if (voice.isPlaying)
		{
			//background.volume = bgVoice;
		}
		else if (!voice.isPlaying)
		{
			//background.volume = bgNoVoice;
		}
	}

	IEnumerator GameStart()
	{
		yield return new WaitForSeconds(2);
		StartCoroutine(_fade.FadeTo(1.0f, 1.0f));
		yield return new WaitForSeconds(5);
		StartCoroutine(_fade.FadeTo(0f, 1.0f));

		Destroy(_fade.gameObject, 2.5f);
	}

	public void SetEvent(EventNames names)
	{
		_names = names;
	}

	void NarrationSwitch()
	{
		switch (_names)
		{
			case EventNames.none:
				break;
			case EventNames.phone:
				Narration(phone, 1);
				break;
			case EventNames.gun:
				Narration(gun, 0);
				break;
			case EventNames.glass:
				Narration(glass, 0);
				break;
			case EventNames.key:
				Narration(key, 0);
				break;
			case EventNames.vhs:
				Narration(vhs, 0);
				break;
			default:
				_names = EventNames.none;
				break;
		}
	}

	void Narration(AudioClip clip, float delay)
	{
		Debug.Log("Playing: " + clip.name);
		voice.PlayOneShot(clip);
		//voice.clip = clip;
		//voice.PlayDelayed(delay);
		_names = EventNames.none;
		//voiceTimeLeft = clip.length;
	}

	public void WindowBreak()
	{
		if (!windowBroke)
		{
			bgVoice = 0.2f;
			bgNoVoice = 0.4f;
			windowBroke = true;
		}
	}

	public void GlassBreak()
	{
		if (!glassBroke)
		{
			glassBroke = true;
			SetEvent(EventNames.glass);
		}
	}

	public void TurnOnTV()
	{
		VHS.SetActive(true);
	}

}
