using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour {

	public UIButton button;
	public UIButton buttonBig;
	public Transform buttonsContainer;
	public UICameraButtons cameraButtons;
	public List<UIButton> buttons;
	public Slider slider;
	public MusicManager musicManager;

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
			UIButton newButton;
			if(instrument.data.size == 1)
				newButton= Instantiate (button);
			else
				newButton= Instantiate (buttonBig);
			
			newButton.transform.SetParent (buttonsContainer);
			newButton.Init(instrument.data, cameraButtons.all[id].renderTexture);
			buttons.Add(newButton);
			id++;
		}
	}
	public void ResetButtons()
	{
		Events.OnResetApp ();
	}
	public void OnSliderChange()
	{
		musicManager.ChangePitchValue (slider.value);
	}

}
