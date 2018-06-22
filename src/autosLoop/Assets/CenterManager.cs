using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterManager : MonoBehaviour {

	public ParticleSystem lane1;
	public ParticleSystem lane2;
	public ParticleSystem lane3;
	public ParticleSystem lane4;

	void Start () {
		Events.OnInstrumentActive += OnInstrumentActive;

		float singleDuration = 0.8f;
		float doubleDuration = 1.9f;

		ParticleSystem.MainModule mainModule1 = lane1.main;
		mainModule1.duration = singleDuration;

		ParticleSystem.MainModule mainModule2 = lane2.main;
		mainModule2.duration = singleDuration;

		ParticleSystem.MainModule mainModule3 = lane3.main;
		mainModule3.duration = singleDuration;

		ParticleSystem.MainModule mainModule4 = lane4.main;
		mainModule4.duration = doubleDuration;


	}
	void Destroy()
	{
		Events.OnInstrumentActive -= OnInstrumentActive;
	}
	void OnInstrumentActive (InstrumentData data, int laneID) {
		float delayDouble = 0.8f;
		float delaySingle = 0.5f;
		float delay = 0;
		switch (laneID) {
		case 1:
			delay = delaySingle;
			break;
		case 2:
			delay = delaySingle;
			break;
		case 3:
			delay = delaySingle;
			break;
		case 4:
			delay = delayDouble;
			break;
		}
		StartCoroutine (OnInstrumentActiveDelayed(laneID, delay));
	}
	IEnumerator OnInstrumentActiveDelayed (int laneID, float delay) {
		yield return new WaitForSeconds (delay);
		switch (laneID) {
		case 1:
			lane1.Play ();
			break;
		case 2:
			lane2.Play ();
			break;
		case 3:
			lane3.Play ();
			break;
		case 4:
			lane4.Play ();
			break;
		}
	}
}
