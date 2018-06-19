using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	static Board mInstance = null;
	public LanesManager lanesManager;
	public InstrumentsManager instrumentsManager;

	public static Board Instance
	{
		get
		{
			return mInstance;
		}
	}
	void Awake()
	{
		if (!mInstance)
			mInstance = this;
		
		lanesManager = GetComponent<LanesManager> ();
		instrumentsManager = GetComponent<InstrumentsManager> ();

		lanesManager.Init ();
	}
}
