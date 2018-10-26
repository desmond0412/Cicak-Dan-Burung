using UnityEngine;
using System.Collections;

public class Frame5VanishingObject : InteractableObject {
	SpriteRenderer objSprite;
	Color spriteColor;
	bool isClicked = false;

	public float timeToFade = 2.0f;

	void OnEnable(){
		isClicked = false;
	}

	void Start(){
		objSprite = GetComponent<SpriteRenderer> ();
		spriteColor = objSprite.color;
	}

	public override void InteractObject ()
	{
		base.InteractObject ();

		if (objSprite && !isClicked) {
			isClicked = true;
			StartCoroutine (VanishCoroutine ());
		}
	}

	IEnumerator VanishCoroutine(){
		for (float t = 0.0f; t < timeToFade; t += Time.fixedDeltaTime) {
			spriteColor.a = Mathf.Lerp (1.0f, 0.0f, t / timeToFade);
			objSprite.color = spriteColor;
			yield return new WaitForFixedUpdate ();
		}
		spriteColor.a = 0.0f;
		objSprite.color = spriteColor;
		gameObject.SetActive (false);

		if (base.isFrameTarget) {
			FindObjectOfType<Frame5Controller> ().setFinish ();
		}
	}
}
