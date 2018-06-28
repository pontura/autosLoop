using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip pick;
	public AudioClip drop;

	public string lane1Sound;
	public string lane2Sound;
	public string lane3Sound;
	public string lane4Sound;

	public AudioSource lane1AudioSource;
	public AudioSource lane2AudioSource;
	public AudioSource lane3AudioSource;
	public AudioSource lane4AudioSource;

	public Vector2 pitchValues;

	public AudioSource uiAudioSource;

	void Start()
	{
		Events.OnInstrumentActive += OnInstrumentActive;
		Events.OnPick += OnPick;
		Events.OnDrop += OnDrop;
		Events.OnResetApp += OnResetApp;
	}
	void Destroy()
	{
		Events.OnInstrumentActive -= OnInstrumentActive;
		Events.OnPick -= OnPick;
		Events.OnDrop -= OnDrop;
		Events.OnResetApp -= OnResetApp;
	}
	void OnResetApp()
	{
		lane1AudioSource.Stop ();
		lane2AudioSource.Stop ();
		lane3AudioSource.Stop ();
		lane4AudioSource.Stop ();
		uiAudioSource.Stop ();
	}
	void OnPick()
	{
		PlayUISFX (pick);
	}
	void OnDrop()
	{
		PlayUISFX (drop);
	}
	void PlayUISFX(AudioClip ac)
	{
		uiAudioSource.PlayOneShot(ac);
	}
	void OnInstrumentActive (InstrumentData data, int laneID) 
	{
		switch (laneID) {
		case 1:
			lane1Sound = data.audioName;
			break;
		case 2:
			lane2Sound = data.audioName;
			break;
		case 3:
			lane3Sound = data.audioName;
			break;
		case 4:
			lane4Sound = data.audioName;
			break;
		}
	}
	public void OnTimerTick()
	{
		float delayDouble = 0.2f;
		float delaySingle = 0.2f;

		if (lane1Sound != "")
			StartCoroutine( PlayClip(delaySingle, lane1AudioSource, lane1Sound));
		if (lane2Sound != "")
			StartCoroutine(PlayClip(delaySingle, lane2AudioSource, lane2Sound));
		if (lane3Sound != "")
			StartCoroutine(PlayClip(delaySingle, lane3AudioSource, lane3Sound));
		if (lane4Sound != "")
			StartCoroutine(PlayClip(delayDouble, lane4AudioSource, lane4Sound));

		lane1Sound = lane2Sound = lane3Sound= lane4Sound = "";
	}
	IEnumerator PlayClip(float delay, AudioSource audioSource, string clipName )
	{
		yield return new WaitForSeconds (delay);
		audioSource.clip = Resources.Load<AudioClip>("Audio/" + clipName);
		audioSource.PlayOneShot(audioSource.clip);
	}

	public void ChangePitchValue(float value)
	{
		//value
		//float newValue = pitchValues;
	}


}
