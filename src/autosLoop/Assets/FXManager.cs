using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

	public GameObject[] FXs;

	void Start () {
		Events.OnFXOn += OnFXOn;
	}
	void OnDestroy () {
		Events.OnFXOn -= OnFXOn;
	}
	void ResetAll()
	{
		foreach (GameObject go in FXs)
			go.SetActive (false);
	}
	void OnFXOn(int id)
	{
		ResetAll ();
		FXs [id - 1].SetActive (true);
	}
}
