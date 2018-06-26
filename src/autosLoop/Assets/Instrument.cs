using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour {

	public InstrumentData data;
	public int laneID;
	bool playing;

	public void Init(int laneID)
	{
		this.laneID = laneID;
	}
	void OnTriggerEnter(Collider other)
	{
		if (playing)
			return;
		Invoke ("Reset", 3);
		playing = true;
		Events.OnInstrumentActive (data, laneID);
		Invoke("PlayAnim", 0.8f);
	}
	public void PlayAnim()
	{
		GetComponent<Animator> ().Play ("play");
	}
	void Reset()
	{
		playing = false;
	}
	public void Idle()
	{
		GetComponent<Animator> ().Play ("idle");
	}

}
