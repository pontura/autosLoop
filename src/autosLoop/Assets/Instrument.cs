using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour {

	public InstrumentData data;
	public int laneID;
	bool playing;
	Collider collider;

	void Start()
	{
		this.collider = GetComponent<Collider> ();
	}
	public void Init(int laneID)
	{
		this.laneID = laneID;

	}
	public void ResetColliderWhenOutOfScreen()
	{
		SetCollider (false);
		Invoke ("Reset", 3);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name != "TriggerCube" || playing)
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
		SetCollider (true);
	}
	void SetCollider(bool setOn)
	{
		collider.enabled = setOn;
	}
	public void Idle()
	{
		GetComponent<Animator> ().Play ("idle");
	}

}
