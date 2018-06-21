using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour {

	public UIButton button;
	public Transform buttonsContainer;
	public UICameraButtons cameraButtons;

	void Start () {
		cameraButtons.Init ();
		Invoke("AddButtons", 0.5f);
	}
	void AddButtons()
	{
		Instrument[] all = Data.Instance.instruments.all;
		int id = 0;
		foreach(Instrument instrument in all)
		{
			UIButton newButton = Instantiate (button);
			newButton.transform.SetParent (buttonsContainer);
			newButton.Init(instrument.data, cameraButtons.all[id].renderTexture);
			id++;
		}
	}

}
