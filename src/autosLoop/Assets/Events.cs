using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	public static System.Action<Instrument> OnRemoveInstrument = delegate { };
	public static System.Action<Instrument, bool, InstrumentToDrag> OnDragOver = delegate { };
	public static System.Action<InstrumentData, int> OnInstrumentActive = delegate { };
	public static System.Action<InstrumentData, RenderTexture> OnStartDragging = delegate { };
	public static System.Action<Slot> OnActivateSlotWithInstrument = delegate { };
	public static System.Action<InstrumentData> OnAddInstrument = delegate { };
	public static System.Action OnPick = delegate { };
	public static System.Action OnDrop = delegate { };
	public static System.Action<Vector3, int> OnAddExplotion = delegate { };
	public static System.Action OnResetApp = delegate { };
	public static System.Action<int> OnFXOn = delegate { };
}
