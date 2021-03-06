﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	public int laneID;
	public int id;
	public SpriteRenderer spriteRenderer;
	public Instrument instrument;
	public int slotSize = 1;

	public void Init(int id, int laneID)
	{
		this.laneID = laneID;
		this.id = id;
		RollOver (false);
	}
	void OnTriggerEnter(Collider other)
	{		
		if (other.name == "dragger") {
			if (!IsCompatible() || HasInstrument ())
				return;
			RollOver (true);
			Events.OnActivateSlotWithInstrument (this);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.name == "dragger")
			RollOver (false);
	}
	void RollOver(bool isOver)
	{
		if (!IsCompatible() || HasInstrument ())
			return;
	}
	public void SetInstrument(Instrument instrument)
	{
		RollOver (false);
		this.instrument = instrument;
		GetComponent<Collider> ().enabled = false;
	}
	public void SetEmpty()
	{
		instrument = null;
		GetComponent<Collider> ().enabled = true;
	}
	public bool HasInstrument()
	{
		if (instrument == null)
			return false;
		else
			return true;
	}
	bool IsCompatible()
	{
		if (Board.Instance.uiDragger.data == null)
			return false;
		if ((Board.Instance.uiDragger.data.size == 2 && slotSize == 2) || (Board.Instance.uiDragger.data.size == 1 && slotSize == 1))
			return true;
		return false;
	}

}
