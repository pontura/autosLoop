using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentsManager : MonoBehaviour {

	public List<InstrumentData> instrumets;
	Slot slotActive;

	void Start()
	{
		Events.OnActivateSlotWithInstrument += OnActivateSlotWithInstrument;
		Events.OnAddInstrument += OnAddInstrument;
	}
	void OnDestroy()
	{
		Events.OnActivateSlotWithInstrument -= OnActivateSlotWithInstrument;
		Events.OnAddInstrument -= OnAddInstrument;
	}
	void OnActivateSlotWithInstrument(Slot slot)
	{
		slotActive = slot;
	}
	void OnAddInstrument(InstrumentData data)
	{
		if (slotActive == null)
			return;

		//agrega 2 por lane:
		int slotID = slotActive.id;
		int duplicatedSlot = 8 / slotActive.slotSize;
		if (slotID >= duplicatedSlot)
			slotID -= duplicatedSlot;
		
		AddInstrumentToSlot (data, slotActive.laneID, slotID);

		slotActive = null;
	}
	public void AddInstrumentToSlot(InstrumentData data,  int laneID,int slotID)
	{
		AddInstrumentToSlotReal (data, laneID, slotID);
		int duplicatedSlot = 8 / slotActive.slotSize;
		AddInstrumentToSlotReal (data, laneID, slotID+duplicatedSlot);	
	}
	void AddInstrumentToSlotReal(InstrumentData data, int laneID, int slotID)
	{
		Lane lanesManager = Board.Instance.lanesManager.GetLane(laneID);
		SlotsManager slotsManager = lanesManager.slotsManager;
		Slot slot = slotsManager.GetSlot (slotID);		
		Instrument instrument = Instantiate (Data.Instance.instruments.GetInstrumentByData(data));
		instrument.transform.SetParent (slot.transform);
		instrument.transform.localPosition = new Vector3 (0, 0, -1);
		instrument.transform.localEulerAngles = Vector3.zero;
		instrument.transform.localScale = slot.transform.localScale;
		instrument.Init (lanesManager.id);
		slot.SetInstrument( instrument );
	}
}
