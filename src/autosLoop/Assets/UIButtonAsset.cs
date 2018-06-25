using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAsset : MonoBehaviour {

	public Transform container;
	public int id;
	public RenderTexture renderTexture;
	public Camera cam;
	Instrument instrument;

	public void Init(Instrument i)
	{
		instrument = Instantiate (i);
		instrument.transform.SetParent (container);
		instrument.transform.localPosition = Vector3.zero;
		instrument.Idle ();
		SetRenderTexture ();
	}
	public void SetRenderTexture()
	{
		renderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
		renderTexture.Create();
		cam.targetTexture = renderTexture;
	}
}
