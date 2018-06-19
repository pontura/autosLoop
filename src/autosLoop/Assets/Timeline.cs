using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour {

	float sec;
	public int second;
	public LanesManager lanesManager;
	public MusicManager musicManager;

	void Start()
	{
		Restart ();
	}
	public void Restart()
	{
		sec = 0;
		second = 1;
		lanesManager.Move ();
	}
	void Update () {
		sec += Time.deltaTime;
		if (sec > second) {
			musicManager.OnTimerTick ();
			second++;
			if (second == 9)				
				Restart ();
		}
	}
}
