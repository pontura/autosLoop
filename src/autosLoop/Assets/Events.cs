using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

	public static System.Action<InstrumentData, int> OnInstrumentActive = delegate { };
}
