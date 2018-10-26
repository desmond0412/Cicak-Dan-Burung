using UnityEngine;
using System.Collections;

public class Frame2Bush : InteractableObject {
	public float edge = 1.5f;
	public GameObject leavesPrefab,trash;

	void Start(){
	}

	public override void InteractObject ()
	{
		base.InteractObject ();

		iTween.ShakeRotation (this.gameObject, iTween.Hash (
				"amount", new Vector3(0.0f,0.0f,15.0f)));

		GameObject go = Instantiate (leavesPrefab,
			new Vector3 (Random.Range (gameObject.transform.position.x - edge, gameObject.transform.position.x + edge),
				transform.position.y,
				transform.position.z), Quaternion.Euler(new Vector3(0.0f,0.0f,Random.Range(0.0f,360.0f)))) as GameObject;

		go.transform.SetParent (trash.transform);
	} 
}
