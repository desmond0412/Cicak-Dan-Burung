using UnityEngine;
using System.Collections;

public class Frame5Pitput : MonoBehaviour {
	Animator anim;

	int idleTrigger,flyTrigger;

	void Awake(){
		idleTrigger = Animator.StringToHash ("IdleTrigger");
		flyTrigger = Animator.StringToHash ("FlyTrigger");
	}

	void Start(){
		anim = GetComponent<Animator> ();
	}

	public void SetFly(){
		if (anim) {
			anim.SetTrigger (flyTrigger);
		}
	}

	public void SetIdle(){
		if (anim) {
			anim.SetTrigger (idleTrigger);
		}
	}
}
