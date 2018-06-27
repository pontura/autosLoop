using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDragger : MonoBehaviour {

	public InstrumentData data;
	public RawImage image;
	public Canvas myCanvas;
	public GameObject draggerItem;

	void Start () {
		Events.OnStartDragging += OnStartDragging;
		Events.OnDragOver += OnDragOver;
		image.enabled = false;
	}
	void OnDestroy () {
		Events.OnStartDragging -= OnStartDragging;
		Events.OnDragOver -= OnDragOver;

	}	
	public void OnClickInstrumentInScene(InstrumentData data)
	{
		print ("OnClickInstrumentInScene " + data);
	}
	void OnStartDragging(InstrumentData data, RenderTexture imageTexture)
	{
		image.enabled = true;
		image.texture = imageTexture;
		this.data = data;
	}

	public bool isScreenTouched;
	void Update () {

		if (Input.GetMouseButtonDown (0))
			isScreenTouched = true;

		if (Input.GetMouseButtonUp (0)) {
			isScreenTouched = false;
			Release ();
			return;
		}

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 1;
		draggerItem.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
		image.transform.position = myCanvas.transform.TransformPoint(pos);
	}
	void Release()
	{
		if (data == null)
			return;
		
		if (draggerItem.transform.position.y>-3)
			Events.OnAddInstrument(data);

		Events.OnDrop ();

		draggerItem.transform.position = new Vector3 (1000, 0, 0);
		image.enabled = false;
		data = null;
	}
	public void OnDragOver(InstrumentData i)
	{
		if (data == null)
			return;
		print (i);
	}
}
