using UnityEngine;
using System.Collections;

public class Frame1Pitput : InteractableObject {
	int flyTriggerHash;
	Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();

		flyTriggerHash = Animator.StringToHash ("FlyTrigger");
	}

	public override void InteractObject ()
	{
		base.InteractObject ();
		if (anim) {
			anim.SetTrigger (flyTriggerHash);
		}
	}
}
