using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDragger : MonoBehaviour {

	InstrumentData data;
	public Image image;
	public Canvas myCanvas;
	public GameObject draggerItem;

	void Start () {
		Events.OnStartDragging += OnStartDragging;
		image.enabled = false;
	}
	void OnDestroy () {
		Events.OnStartDragging -= OnStartDragging;
	}	
	void OnStartDragging(InstrumentData data)
	{
		image.enabled = true;
		AddAsset(data);
	}
	void Update () {
		if (data == null)
			return;

		if (Input.GetMouseButtonUp (0)) {
			Release ();
			return;
		}

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0;
		draggerItem.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
		image.transform.position = myCanvas.transform.TransformPoint(pos);
	}
	void AddAsset(InstrumentData data) {
		this.data = data;
		Sprite sprite = Instantiate(Resources.Load<Sprite>("instruments/" + data.spriteName)) as Sprite;
		image.sprite = sprite;
	}
	void Release()
	{
		Events.OnAddInstrument(data);
		draggerItem.transform.position = new Vector3 (1000, 0, 0);
		image.enabled = false;
		data = null;
	}
}
