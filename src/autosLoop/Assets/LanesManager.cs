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
	public Lane GetLane(int id)
	{
		foreach (Lane lane in lanes)
			if (lane.id == id)
				return lane;
		return null;
	}

}
