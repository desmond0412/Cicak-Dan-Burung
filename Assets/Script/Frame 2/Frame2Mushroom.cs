using UnityEngine;
using System.Collections;

public class Frame2Mushroom : InteractableObject {
	int squashHashTrigger;

	Animator anim;

	void Awake(){
		squashHashTrigger = Animator.StringToHash ("SquashTrigger");
	}

	void Start () {
		anim = GetComponent<Animator> ();
	}

	public override void InteractObject ()
	{
		base.InteractObject ();
		anim.SetTrigger (squashHashTrigger);
	}
}
