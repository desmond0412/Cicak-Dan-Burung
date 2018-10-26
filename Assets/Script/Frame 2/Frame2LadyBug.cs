using UnityEngine;
using System.Collections;

public class Frame2LadyBug : InteractableObject {
	Animator anim;

	int walkingTriggerHash;

	void Awake(){
		anim = GetComponent<Animator> ();
	}

	void Start(){
		walkingTriggerHash = Animator.StringToHash ("WalkTrigger");
	}

	public override void InteractObject ()
	{
		base.InteractObject ();

		anim.SetTrigger (walkingTriggerHash);
	}
}