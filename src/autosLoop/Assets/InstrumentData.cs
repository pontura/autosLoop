using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InstrumentData {

	public int id;
	public types type;
	public int size;
	public enum types
	{
		BICI,
		AUTO,
		BONDI
	}

}
