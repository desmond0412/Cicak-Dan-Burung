using UnityEngine;
using System.Collections;

public class Frame4Burung : MonoBehaviour {
	public Transform startLine,finishLine;
	public float minX,maxX;

	float xVelocity;

	void Awake(){
		xVelocity = Random.Range (minX, maxX);
	}

	void FixedUpdate(){
		if (transform.position.x > finishLine.position.x) {
			transform.position = new Vector3 (startLine.position.x,
				transform.position.y,
				transform.position.z);
		}

		transform.Translate (Vector3.right * xVelocity * Time.fixedDeltaTime);
	}
}
