using UnityEngine;
using System.Collections;

public class Frame2Leaves : MonoBehaviour {
	float x = 1.0f;

	void Start () {
		Destroy (this.gameObject, 20.0f);

		ReactivateITween (true);
	}

	void Update(){
		x += Time.deltaTime * 0.5f;

		transform.position = new Vector3(transform.position.x,
			transform.position.y - Time.deltaTime * 0.8f, 
			transform.position.z);
	}

	void ReactivateITween(bool dir){
		iTween.MoveBy (this.gameObject, iTween.Hash ("x", dir ? x : -1 * x,
			"speed", 1.5f,
			"space",Space.World,
			"easetype", iTween.EaseType.easeInOutQuad,
			"oncomplete", "ReactivateITween",
			"oncompleteparams", !dir));
	}
}
