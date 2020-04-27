using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventNames
{
	none,
	intro,
	unlock,
	gun,
	vhs,
	pieces,
	end,
}

public class EventManager : MonoBehaviour
{
	private EventNames _names;

	#region Audio 
	// Audio sources
	public AudioSource background;
	private AudioSource voice;

	// Selects volume of ambience
	private float bgVoice = 0.1f;
	private float bgNoVoice = 0.2f;
	private bool windowBroke;
	private float voiceTimeLeft;

	// Audio for voice clips
	public AudioClip intro;
	public AudioClip unlock;
	public AudioClip vhs;
	public AudioClip gun;
	public AudioClip pieces;
	public AudioClip end;
	#endregion


	private float start = 3f;
	public TitleFade _fade;
	public Phone _phone;
	public GameObject VHS;



	// Start is called before the first frame update
	void Start()
	{
		_names = EventNames.none;
		voice = GetComponent<AudioSource>();
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
			background.volume = bgVoice;
		}
		else if (!voice.isPlaying)
		{
			background.volume = bgNoVoice;
		}
	}

	IEnumerator GameStart()
	{
		
		StartCoroutine(_fade.FadeTo(1.0f, 1.0f, 2));
		StartCoroutine(_fade.FadeTo(0f, 1.0f, 7));
		Destroy(_fade.gameObject, 9.5f);
		yield return null;
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
			case EventNames.intro:
				Narration(intro, 2);
				break;
			case EventNames.unlock:
				Narration(unlock, 0);
				break;
			case EventNames.vhs:
				Narration(vhs, 0);
				break;
			case EventNames.gun:
				Narration(gun, 0);
				break;
			case EventNames.pieces:
				Narration(pieces, 0);
				break;
			case EventNames.end:
				Narration(end, 0);
				break;
			default:
				_names = EventNames.none;
				break;
		}
	}

	void Narration(AudioClip clip, float delay)
	{
		Debug.Log("Playing: " + clip.name);
		//voice.PlayOneShot(clip);
		voice.clip = clip;
		voice.PlayDelayed(delay);
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

	// Introduction voice
	public void PickUpPhone()
	{
		SetEvent(EventNames.intro);
	}

	// Tells player to unlock door
	public void PickUpKey()
	{
		SetEvent(EventNames.unlock);
	}

	// Unlocked the door
	public void UnlockedDraw()
	{
		SetEvent(EventNames.vhs);
	}

	// Placed VHS tape in cassette player
	public void TurnOnTV()
	{
		VHS.SetActive(true);
	}

	// Picked up one of the puzzle pieces
	public void PickUpPaper()
	{
		SetEvent(EventNames.gun);
	}

	// Shot all of the targets
	public void DestroyedTargets()
	{
		SetEvent(EventNames.pieces);
	}

	// Placed all of the correct pieces on clipboard
	public void EndVoice()
	{
		SetEvent(EventNames.end);
	}
}
