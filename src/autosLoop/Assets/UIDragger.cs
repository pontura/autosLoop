using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDragger : MonoBehaviour {

	public InstrumentData data;
	public RawImage image;
	public Canvas myCanvas;
	public GameObject draggerItem;
	public UIButtons uiButtons;
	public Text field;

	void Start () {
		Events.OnStartDragging += OnStartDragging;
		Events.OnDragOver += OnDragOver;
		image.enabled = false;
	}
	void OnDestroy () {
		Events.OnStartDragging -= OnStartDragging;
		Events.OnDragOver -= OnDragOver;
	}	
	void OnStartDragging(InstrumentData data, RenderTexture imageTexture)
	{
		image.enabled = true;
		image.texture = imageTexture;
		this.data = data;
	}

	public float timeStartedDragging;
	public bool isScreenTouched;
	Vector3 mousePos;

	void Update () {
		if (Data.Instance.control == Data.controls.MOUSE) {
			if (Input.GetMouseButtonDown (0))
				OnPress ();
			else if (Input.GetMouseButtonUp (0))
				OnRelease ();
			mousePos = Input.mousePosition;
		} else  {
			if (Input.touchCount > 0) {
				if (Input.GetTouch(0).phase == TouchPhase.Began)
					OnPress ();
				if (Input.GetTouch(0).phase == TouchPhase.Ended)
					OnRelease ();
			}
			mousePos = Input.GetTouch(0).position;
		}
		mousePos.z = 1;
		draggerItem.transform.position = Camera.main.ScreenToWorldPoint (mousePos);

		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
		image.transform.position = myCanvas.transform.TransformPoint (pos);

	}
	void OnPress()
	{
		field.text = "P " + Time.time;
		Invoke("StartDraggingSceneObject", 0.05f);
	}
	void OnRelease()
	{
		field.text = "_R " + Time.time;
		draggerItem.transform.position = new Vector3 (1000, draggerItem.transform.position.y, draggerItem.transform.position.z);

		if (Time.time < timeStartedDragging + 0.1f)
			return;
		
		isScreenTouched = false;
		Release ();
	}
	void Release()
	{
		instrumentDragged = null;

		if (data == null)
			return;
		
		if (draggerItem.transform.position.y>-3)
			Events.OnAddInstrument(data);

		Events.OnDrop ();

		image.enabled = false;
		data = null;
	}
	public Instrument instrumentDragged;
	InstrumentToDrag draggedItem;
	public void OnDragOver(Instrument i, bool isOver, InstrumentToDrag _draggedItem)
	{
		
		if (isOver) {
			instrumentDragged = i;
			this.draggedItem = _draggedItem;
		}
		else if(instrumentDragged != null && _draggedItem == this.draggedItem)
			instrumentDragged = null;
	}
	void StartDraggingSceneObject()
	{
		RenderTexture rt = null;
		InstrumentData data = null;
		if (instrumentDragged == null)
			return;

		timeStartedDragging = Time.time;
		foreach( UIButton uiButton in uiButtons.buttons)
		{
			if (uiButton.data.id == instrumentDragged.data.id && uiButton.data.type == instrumentDragged.data.type) {
				rt = (RenderTexture)uiButton.image.texture;
				data = uiButton.data;
			}
		}
		if (data != null) {
			OnStartDragging (data, rt);
			Events.OnRemoveInstrument (instrumentDragged);
		}

	}
}