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
		Events.OnInstrumentActive (data, laneID);
	}

}
