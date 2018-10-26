using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {
	public delegate void InteractAction ();
	public event InteractAction OnInteract;

	public bool isFrameTarget;
	public SFXProfile interactSound = null;
	public float soundDelay = 0.0f;

	public virtual void InteractObject(){
		if (OnInteract != null) {
			OnInteract ();
		}
		if (interactSound != null) {
			FindObjectOfType<AudioManager> ().PlaySFX (interactSound, soundDelay);
		}
	}
}
