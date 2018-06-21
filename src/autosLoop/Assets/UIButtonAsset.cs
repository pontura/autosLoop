using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonAsset : MonoBehaviour {

	public Transform container;
	public int id;
	public RenderTexture renderTexture;
	public Camera cam;

	public void Init(Instrument i)
	{
		Instrument newGO = Instantiate (i);
		newGO.transform.SetParent (container);
		newGO.transform.localPosition = Vector3.zero;
		SetRenderTexture ();
	}
	public void SetRenderTexture()
	{
		renderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
		renderTexture.Create();
		cam.targetTexture = renderTexture;
	}
}
