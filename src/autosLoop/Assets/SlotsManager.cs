using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour {

	public Slot slot;
	public int totalSlots;
	public float screenWidth = 18;
	public List<Slot> all;

	public void Init()
	{
		for (int a = 0; a < totalSlots*2; a++) {
			float separation = a * (screenWidth / 8);
			Slot newSlot = Instantiate (slot);
			newSlot.transform.SetParent (transform);
			Vector3 pos = new Vector3 (separation-(screenWidth/2), 0, 0);
			newSlot.transform.localPosition = pos;
			newSlot.transform.localEulerAngles = Vector3.zero;
			newSlot.Init (a);
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
		
}
