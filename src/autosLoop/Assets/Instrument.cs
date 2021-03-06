﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour {

	public InstrumentData data;
	public int laneID;
	public int slotID;
	bool playing;
	Collider collider;
	public InstrumentToDrag instrumentToDrag;

	void Awake()
	{
		instrumentToDrag.SetState (false);
	}
	void Start()
	{
		this.collider = GetComponent<Collider> ();
	}
	public void Init(int laneID, int slotID)
	{
		instrumentToDrag.SetState (true);
		this.laneID = laneID;
		this.slotID = slotID;
		instrumentToDrag.SetState (true);
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

		Invoke ("Reset", 4);
		playing = true;
		Events.OnInstrumentActive (data, laneID);
		Invoke("PlayAnim", 0.6f);
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
	public void ClearInstrument()
	{
		Invoke ("Done", (float)Random.Range (1, 20) / 20);
	}
	void Done()
	{
		Destroy (this.gameObject);
		Events.OnAddExplotion (transform.position, laneID);
	}

}
