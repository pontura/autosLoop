using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	public int laneID;
	public int id;
	public SpriteRenderer spriteRenderer;
	public Instrument instrument;

	public void Init(int id, int laneID)
	{
		this.laneID = laneID;
		this.id = id;
		RollOver (false);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.name == "dragger") {
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
		Color c = spriteRenderer.color;

		if (isOver) 
			c.a = 1;
		else
			c.a = 0.15f;
			
		spriteRenderer.color = c;
	}
	public void SetInstrument(Instrument instrument)
	{
		RollOver (false);
		this.instrument = instrument;
		GetComponent<Collider> ().enabled = false;
	}
}
