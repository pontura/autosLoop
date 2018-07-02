using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentToDrag : MonoBehaviour {
	
	public void SetState(bool isOn) {
		gameObject.SetActive (isOn);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "dragger") {
			Events.OnDragOver (GetComponentInParent<Instrument> (), true, this);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "dragger") {
			Events.OnDragOver (GetComponentInParent<Instrument> (), false, this);
		}
	}
}
