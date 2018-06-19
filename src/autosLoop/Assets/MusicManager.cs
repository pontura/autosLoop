using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip loop1;
	public AudioClip loop2;
	public AudioClip loop3;
	public AudioClip loop4;

	public string lane1Sound;
	public string lane2Sound;
	public string lane3Sound;
	public string lane4Sound;

	public AudioSource lane1AudioSource;
	public AudioSource lane2AudioSource;
	public AudioSource lane3AudioSource;
	public AudioSource lane4AudioSource;

	void Start()
	{
		Events.OnInstrumentActive += OnInstrumentActive;
	}
	void Destroy()
	{
		Events.OnInstrumentActive -= OnInstrumentActive;
	}

	void OnInstrumentActive (InstrumentData data, int laneID) 
	{
		print ("OnInstrumentActive " + Time.time);
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

		if (lane1Sound != "")
			PlayClip(lane1AudioSource, lane1Sound);
		if (lane2Sound != "")
			PlayClip(lane2AudioSource, lane2Sound);
		if (lane3Sound != "")
			PlayClip(lane3AudioSource, lane3Sound);
		if (lane4Sound != "")
			PlayClip(lane4AudioSource, lane4Sound);

		lane1Sound = lane2Sound = lane3Sound= lane4Sound = "";
	}
 	void PlayClip(AudioSource audioSource, string clipName)
	{
		audioSource.clip = Resources.Load<AudioClip>("Audio/" + clipName);
		audioSource.PlayOneShot(audioSource.clip);
	}
//	void PlayClip(AudioSource audioSource, string clipName)
//	{
//		
//		StartCoroutine (OnCreateAudioSource (clipName));	
//	}
//
//	IEnumerator OnCreateAudioSource (string clipName)
//	{ 
//		AudioSource audio = gameObject.AddComponent<AudioSource> ();
//		audio.clip = Resources.Load<AudioClip>("Audio/" + clipName);
//		audio.Play();
//		yield return new WaitForSeconds(audio.clip.length);
//		Destroy (audio);
//	}



}
