using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraButtons : MonoBehaviour {

	public UIButtonAsset button;
	public UIButtonAsset buttonBig;
	public List<UIButtonAsset> all;

	public void Init () {
		int id = 0;
		foreach (Instrument i in Data.Instance.instruments.all) {
			
			UIButtonAsset newButton;

			if(i.data.size==1)
				newButton = Instantiate (button);
			else
				newButton = Instantiate (buttonBig);
			
			newButton.transform.SetParent (transform);
			newButton.transform.localPosition = new Vector3 (id*100, 0, 0);
			newButton.id = id;
			newButton.Init (i);
			id++;
			all.Add (newButton);
		}
	}
}
