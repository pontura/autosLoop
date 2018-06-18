using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {

	public InstrumentData data;
	public Image image;

	public void Init(InstrumentData data) {
		this.data = data;
		string spriteName = "";
		switch (data.type) {
		case InstrumentData.types.AUTO:
			spriteName = "auto";
			break;
		case InstrumentData.types.BONDI:
			spriteName = "bondi";
			break;
		case InstrumentData.types.BICI:
			spriteName = "bici";
			break;			
		}
		spriteName += data.id;
		Sprite sprite = Instantiate(Resources.Load<Sprite>("instruments/" + spriteName)) as Sprite;
		image.sprite = sprite;
	}
}
