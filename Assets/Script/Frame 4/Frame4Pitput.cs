using UnityEngine;
using System.Collections;

public class Frame4Pitput : MonoBehaviour {
	public bool startMovement = false;

	[SerializeField]
	private bool _isTopLock;
	public bool isTopLock{
		get{
			return _isTopLock;
		}
		set{
			_isTopLock = value;
		}
	}

	[SerializeField]
	private bool _isBottomLock;
	public bool isBottomLock{
		get{
			return _isBottomLock;
		}
		set{
			_isBottomLock = value;
		}
	}

	[SerializeField]
	private bool _isFrontLock;
	public bool isFrontLock{
		get{
			return _isFrontLock;
		}
		set{
			_isFrontLock = value;
		}
	}

	Animator anim;
	int isShockHash;

	void Awake(){
		isShockHash = Animator.StringToHash ("IsShock");
	}

	void Start(){
		anim = GetComponent<Animator> ();
	}

	public void SetupPitput(){
		startMovement = false;
		transform.localPosition = new Vector3 (-2.0f, 1.5f, 0.0f);
		isBottomLock = false;
		isTopLock = false;
		isFrontLock = false;

		if (anim) {
			anim.SetBool (isShockHash, false);
		}
	}

	public void SetFinish(){
		startMovement = false;
		isBottomLock = true;
		isTopLock = true;
		isFrontLock = true;

		if (anim) {
			anim.SetBool (isShockHash, true);	
		}
	}
}
