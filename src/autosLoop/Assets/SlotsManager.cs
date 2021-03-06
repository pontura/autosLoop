﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour {

	public Slot slot;
	public int totalSlots;
	public float screenWidth = 18;
	public int slotSize = 1;
	public List<Slot> all;
	public float offset;

	public void Init(int laneID)
	{
		for (int a = 0; a < totalSlots; a++) {
			float separation = a * (screenWidth / 8) * slotSize;
			Slot newSlot = Instantiate (slot);
			newSlot.transform.SetParent (transform);
			Vector3 pos = new Vector3 (separation-(screenWidth/2) +offset, 0, 0);
			newSlot.transform.localPosition = pos;
			newSlot.transform.localEulerAngles = Vector3.zero;
			newSlot.Init (a,laneID);
			all.Add (newSlot);
		}
	}
	public Slot GetSlot(int slotID)
	{
		foreach (Slot slot in all)
			if (slot.id == slotID)
				return slot;
		return null;
	}
	public void ResetSlot(int slotID)
	{
		foreach (Slot slot in all) {
			if (slot.id == slotID)
				slot.SetEmpty ();
		}
	}
		
}
