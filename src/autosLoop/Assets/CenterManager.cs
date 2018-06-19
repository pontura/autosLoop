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
	}
	void Destroy()
	{
		Events.OnInstrumentActive -= OnInstrumentActive;
	}

	void OnInstrumentActive (InstrumentData data, int laneID) {
		GameObject go;
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
