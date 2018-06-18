using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentsManager : MonoBehaviour {

	public List<InstrumentData> instrumets;

	public void Init()
	{
		Invoke ("Delayed", 0.5f);
	}
	public void Delayed()
	{
		AddInstrumentToSlot (0, 1, 0);
		AddInstrumentToSlot (1, 1, 1);
		AddInstrumentToSlot (2, 1, 2);

		AddInstrumentToSlot (3, 2, 6);
		AddInstrumentToSlot (8, 2, 5);
		AddInstrumentToSlot (9,2, 4);

		AddInstrumentToSlot (10, 3, 1);
		AddInstrumentToSlot (0, 3, 5);
		AddInstrumentToSlot (1, 3, 7);

		AddInstrumentToSlot (4, 4, 0);
		AddInstrumentToSlot (5, 4, 2);
		AddInstrumentToSlot (6, 4, 4);
		AddInstrumentToSlot (7, 4, 6);
	}
	public void AddInstrumentToSlot(int instrumentID,  int laneID,int slotID)
	{
		AddInstrumentToSlotReal (instrumentID, laneID, slotID);
		AddInstrumentToSlotReal (instrumentID, laneID, slotID+8);	
	}
	void AddInstrumentToSlotReal(int instrumentID, int laneID, int slotID)
	{
		Lane lanesManager = Board.Instance.lanesManager.GetLane(laneID);
		print (lanesManager);
		print (lanesManager.slotsManager);
		SlotsManager slotsManager = lanesManager.slotsManager;
		Slot slot = slotsManager.GetSlot (slotID);
		print (slotID);
		Instrument instrument = Instantiate (Data.Instance.instruments.GetInstrument(instrumentID));
		instrument.transform.SetParent (slot.transform);
		instrument.transform.localPosition = Vector3.zero;
		instrument.transform.localEulerAngles = Vector3.zero;
		instrument.Init (lanesManager.id);
	}
}
