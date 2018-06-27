using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

	public int id;
	public float direction;
	public float speed;
	public SlotsManager slotsManager;
	int totalSlots = 18;
	public float startingPosition;
	public float toPosition;
	public void Init()
	{
		slotsManager.Init (id);	
		Vector3 pos = transform.localPosition;
		pos.z = -(float)id / 5;
		transform.localPosition = pos;
	}
	public void StartMoving()
	{
		StopAllCoroutines ();
		Vector3 pos = transform.localPosition;
		if (direction == -1 && transform.localPosition.x < -16)
			pos.x = startingPosition;
		if (direction == 1 && transform.localPosition.x > 16)
			pos.x = startingPosition;		
		transform.localPosition = pos;
		pos.x = transform.localPosition.x+toPosition;
		StartCoroutine (MoveOverSeconds(pos, 8));
	}
	public IEnumerator MoveOverSeconds (Vector3 end, float seconds)
	{
		float elapsedTime = 0;
		Vector3 startingPos = transform.position;
		while (elapsedTime < seconds)
		{
			transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		transform.position = end;
	}
}
