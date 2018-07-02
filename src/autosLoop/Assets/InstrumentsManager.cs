using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentsManager : MonoBehaviour {

	Slot slotActive;
	public List<Instrument> all;
	LanesManager lanesManager;
	public GameObject clear_car;
	public GameObject clear_bondi;

	void Start()
	{
		Events.OnActivateSlotWithInstrument += OnActivateSlotWithInstrument;
		Events.OnRemoveInstrument += OnRemoveInstrument;
		Events.OnAddInstrument += OnAddInstrument;
		Events.OnResetApp += OnResetApp;
		Events.OnAddExplotion += OnAddExplotion;
		lanesManager = GetComponent< LanesManager> ();
	}
	void OnDestroy()
	{
		Events.OnActivateSlotWithInstrument -= OnActivateSlotWithInstrument;
		Events.OnRemoveInstrument -= OnRemoveInstrument;
		Events.OnAddInstrument -= OnAddInstrument;
		Events.OnResetApp -= OnResetApp;
		Events.OnAddExplotion -= OnAddExplotion;
	}
	void OnResetApp()
	{
		foreach (Instrument i in all) {
			lanesManager.ResetSlots (i.laneID, i.slotID);
			i.ClearInstrument ();
		}
		all.Clear ();
	}
	void OnActivateSlotWithInstrument(Slot slot)
	{
		slotActive = slot;
	}
	void OnAddInstrument(InstrumentData data)
	{
		if (slotActive == null)
			return;
		
		int slotID = slotActive.id;
		AddInstrumentToSlot (data, slotActive.laneID, slotID);

		slotActive = null;
	}
	public void AddInstrumentToSlot(InstrumentData data,  int laneID,int slotID)
	{
		int sequence = 0;
		foreach (Lane lane in Board.Instance.lanesManager.GetLanes(laneID))
			AddInstrumentToSlotReal (data, lane, slotID);
	}
	public void RemoveInstrument(InstrumentData data,  int laneID,int slotID)
	{
		int sequence = 0;
		foreach (Lane lane in Board.Instance.lanesManager.GetLanes(laneID))
			AddInstrumentToSlotReal (data, lane, slotID);
	}
	void AddInstrumentToSlotReal(InstrumentData data, Lane lanesManager, int slotID)
	{
		SlotsManager slotsManager = lanesManager.slotsManager;
		Slot slot = slotsManager.GetSlot (slotID);		
		Instrument instrument = Instantiate (Data.Instance.instruments.GetInstrumentByData(data));
		instrument.transform.SetParent (slot.transform);
		instrument.transform.localPosition = new Vector3 (0, 0, -1);
		instrument.transform.localEulerAngles = Vector3.zero;
		instrument.transform.localScale = slot.transform.localScale;
		instrument.Init (lanesManager.id, slot.id);
		slot.SetInstrument( instrument );
		all.Add (instrument);
	}
	void OnRemoveInstrument(Instrument i)
	{
		List<Instrument> allToRemove = new List<Instrument> ();

		int otherInstrumentSlotID = 0;

		if (i.slotID < 8)
			otherInstrumentSlotID = i.slotID + 8;
		else
			otherInstrumentSlotID = i.slotID - 8;
		
		foreach(Instrument instrument in all)
		{
			if (instrument.laneID == i.laneID && (instrument.slotID == i.slotID || instrument.slotID == otherInstrumentSlotID))
				allToRemove.Add (instrument);
		}

		all.Remove (allToRemove[0]);
		all.Remove (allToRemove[1]);



		lanesManager.ResetSlots (i.laneID, i.slotID);

		GameObject.Destroy( allToRemove[0].gameObject );
		GameObject.Destroy( allToRemove[1].gameObject );
	}
	void OnAddExplotion(Vector3 pos, int laneID)
	{
		GameObject explotion = clear_car;
		if (laneID == 4)
			explotion = clear_bondi;
		GameObject go = Instantiate (explotion);
		go.transform.position = pos;
			
	}
}
