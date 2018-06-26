using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour {

	public InstrumentData data;
	public RawImage image;

	public void Init(InstrumentData data, RenderTexture rt) {
		this.data = data;
		image.texture = rt;
	}
	public void OnClicked()
	{
		Events.OnPick ();
		Events.OnStartDragging (data, (RenderTexture)image.texture);
	}
}
