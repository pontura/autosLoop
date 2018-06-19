using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentsData : MonoBehaviour {

	public Instrument[] all;

	public Instrument GetInstrument(int id)
	{
		return all [id];
	}
	public Instrument GetInstrumentByData(InstrumentData data)
	{
		foreach (Instrument i in all)
			if (data == i.data)
				return i;
		return null;
	}
}
