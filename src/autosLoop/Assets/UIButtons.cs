using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour {

	public UIButton button;
	public Transform buttonsContainer;

	void Start () {
		AddButtons ();
	}
	void AddButtons()
	{
		Instrument[] all = Data.Instance.instruments.all;
		foreach(Instrument instrument in all)
		{
			UIButton newButton = Instantiate (button);
			newButton.transform.SetParent (buttonsContainer);
			newButton.Init (instrument.data);
		}
	}
}
