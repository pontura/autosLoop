using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentsData : MonoBehaviour {

	public Instrument[] all;

	public Instrument GetInstrument(int id)
	{
		return all [id];
	}
}
