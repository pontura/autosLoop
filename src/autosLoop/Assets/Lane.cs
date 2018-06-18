using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

	public int id;
	public float direction;
	public float speed;
	public SlotsManager slotsManager;
	int totalSlots = 18;
	public void Init()
	{
		slotsManager.Init ();
		StartMoveing ();
	}
	void StartMoveing()
	{
		Vector3 pos = transform.localPosition;
		pos.x =  -18 * direction;
		transform.localPosition = pos;
		pos.x = 0;
		StartCoroutine (MoveOverSeconds(pos, 8));
	}
//	void Update () {
//
//		Vector2 pos = transform.localPosition;
//
//		print (Time.time + " pos: " + pos.x);
//
//		if (pos.x < 0 && direction == -1)
//			pos.x = totalSlots;
//		else if (pos.x > 0 && direction == 1)
//			pos.x = -totalSlots;
//		else
//			pos.x += direction * Time.deltaTime * speed;
//		
//		transform.localPosition = pos;
//	}
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
		StartMoveing ();
	}
}
