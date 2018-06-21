using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

	public static System.Action<InstrumentData, int> OnInstrumentActive = delegate { };
	public static System.Action<InstrumentData, RenderTexture> OnStartDragging = delegate { };
	public static System.Action<Slot> OnActivateSlotWithInstrument = delegate { };
	public static System.Action<InstrumentData> OnAddInstrument = delegate { };
}
