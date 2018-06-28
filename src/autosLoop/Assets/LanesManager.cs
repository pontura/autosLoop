using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesManager : MonoBehaviour {

	public List<Lane> lanes;

	public void Init()
	{
		foreach (Lane lane in lanes) 
			lane.Init ();
	}
	public List<Lane> GetLanes(int id)
	{
		List<Lane> l = new List<Lane> ();
		foreach (Lane lane in lanes)
			if (lane.id == id)
				l.Add( lane );
		return l;
	}
	public Lane GetLane(int id)
	{
		foreach (Lane lane in lanes)
			if (lane.id == id)
				return lane;
		return null;
	}
	public void Move()
	{
		foreach (Lane lane in lanes)
			lane.StartMoving ();
	}
	public void ResetSlots(int laneID, int slotID)
	{
		foreach (Lane lane in lanes) {
			if (lane.id == laneID)
				lane.slotsManager.ResetSlot (slotID);
		}
	}

}
