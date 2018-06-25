using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour {

	public InstrumentData data;
	public int laneID;

	public void Init(int laneID)
	{
		this.laneID = laneID;
	}
	void OnTriggerEnter(Collider other)
	{
		print (other.name);
		Events.OnInstrumentActive (data, laneID);
		Invoke("PlayAnim", 0.8f);
	}
	public void PlayAnim()
	{
		GetComponent<Animator> ().Play ("play");
	}
	public void Idle()
	{
		GetComponent<Animator> ().Play ("idle");
	}

}
