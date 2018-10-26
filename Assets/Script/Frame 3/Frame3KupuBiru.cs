using UnityEngine;
using System.Collections;

public class Frame3KupuBiru : InteractableObject {
	Animator anim;

	int flyTriggerHash;

	void Awake(){
		flyTriggerHash = Animator.StringToHash ("FlyTrigger");
	}

	void Start(){
		anim = GetComponent<Animator> ();
	}

	public override void InteractObject ()
	{
		base.InteractObject ();
		if (anim) {
			anim.SetTrigger (flyTriggerHash);
		}
	}
}
