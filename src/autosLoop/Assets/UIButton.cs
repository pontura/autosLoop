using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {

	public InstrumentData data;
	public Image image;

	public void Init(InstrumentData data) {
		this.data = data;
		Sprite sprite = Instantiate(Resources.Load<Sprite>("instruments/" + data.spriteName)) as Sprite;
		image.sprite = sprite;
	}
}
