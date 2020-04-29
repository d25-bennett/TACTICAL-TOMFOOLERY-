using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public bool IsCredits;

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

    
	public TitleFade _title;
	public Phone _phone;
	public GameObject _tvScreen;
	public GameObject _morseCode;
	public clipboardRenderer _clipBoard;
    public TargetSystem _targets;
    public PaperSystem _paper;
	public OVRScreenFade fade;
	public TitleFade _credits;
	public Light creditsLight;


    // Start is called before the first frame update
    void Start()
	{
		_names = EventNames.none;
		voice = GetComponent<AudioSource>();
		StartCoroutine(GameStart());
		if (IsCredits)
		{
			StartCoroutine(_credits.FadeTo(1.0f, 1.0f, 9));
			StartCoroutine(_credits.FadeTo(0f, 1.0f, 16));
			StartCoroutine(Ending());
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		if (!IsCredits)
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
	}

	IEnumerator Ending()
	{
		yield return new WaitForSeconds(2.1f);
		creditsLight.intensity = Mathf.Lerp(0, 1, 1);
		yield return new WaitForSeconds(18);
		fade.FadeOut();
		creditsLight.intensity = Mathf.Lerp(1, 0,1);
		yield return new WaitForSeconds(3);
		Debug.Log("Application Quit");
		Application.Quit();
	}

	IEnumerator GameStart()
	{
		
		StartCoroutine(_title.FadeTo(1.0f, 1.0f, 2));
		StartCoroutine(_title.FadeTo(0f, 1.0f, 7));
		Destroy(_title.gameObject, 9.5f);
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
				Narration(intro, 1);
				break;
			case EventNames.unlock:
				Narration(unlock, 0);
				break;
			case EventNames.vhs:
				Narration(vhs, 3);
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
		voice.clip = clip;
		voice.PlayDelayed(delay);
		_names = EventNames.none;
	}

	public void WindowBreak()
	{
		if (!windowBroke)
		{
			bgVoice = 0.3f;
			bgNoVoice = 0.8f;
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
        _paper.SpawnCupboardPaper();
        SetEvent(EventNames.vhs);
	}

	// Placed VHS tape in cassette player
	public void TurnOnTV()
	{
		_clipBoard.MorseText();
        _paper.SpawnVHSPaper();
        _tvScreen.SetActive(true);
		_morseCode.SetActive(true);
    }

	// Picked up one of the puzzle pieces
	public void PickUpPaper()
	{
		_morseCode.SetActive(false);
		_targets.StartPuzzle();
		SetEvent(EventNames.gun);
	}

	// Shot all of the targets
	public void DestroyedTargets()
	{
        _paper.SpawnTargetPaper();
		_clipBoard.EndText();
        SetEvent(EventNames.pieces); 
    }

	// Placed all of the correct pieces on clipboard
	public void EndVoice()
	{
		SetEvent(EventNames.end);
		StartCoroutine(EndFade());
	}

	IEnumerator EndFade()
	{
		yield return new WaitForSeconds(3);
		fade.FadeOut();
		yield return new WaitForSeconds(3);
		
		SceneManager.LoadScene(1);
	}
}
