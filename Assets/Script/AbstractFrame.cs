using UnityEngine;
using System.Collections;

public class AbstractFrame : MonoBehaviour {
	[SerializeField]
	protected InteractableObject currentSelectedObject;

	[SerializeField]
	GameObject NextButton;

	public SFXProfile BGM;
	public SFXProfile startVO;

	public bool bypassNoSelectedObject = false;
	public bool isFinish = false;

	virtual protected void Awake(){
		
	}

	virtual protected void Start(){

	}

	virtual protected void OnEnable(){
		if (BGM != null) {
			AudioManager.instance.PlayBGM (BGM, 0.5f);
		}
		if (startVO != null) {
			AudioManager.instance.PlayVoiceOver (startVO, 0.75f);
		} else {
			AudioManager.instance.StopVoiceOver ();
		}
	}

	virtual protected void Update(){
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			switch (touch.phase) {
			case TouchPhase.Began:
				HandleBegan (touch.position);
				break;
			case TouchPhase.Moved:
				HandleMoved (touch.position,currentSelectedObject);
				break;
			case TouchPhase.Ended:
				HandleEnded (touch.position,currentSelectedObject);
				break;
			}
		} else {
			currentSelectedObject = null;
		}

//		#if UNITY_EDITOR
//		// Simulate touch events from mouse events
//		if (Input.touchCount == 0) {
//			if (Input.GetMouseButtonUp(0) ) {
//				HandleEnded(Input.mousePosition,currentSelectedObject);
//			}
//			if (Input.GetMouseButtonDown(0) ) {
//				HandleBegan(Input.mousePosition);
//			}
//			if (Input.GetMouseButton(0) ) {
//				HandleMoved(Input.mousePosition,currentSelectedObject);
//			}
//		}
//		#endif

		if (isFinish) {
			NextButton.SetActive (true);
		} else {
			NextButton.SetActive (false);
		}

//		#if UNITY_EDITOR
//		Debug.Log(currentSelectedObject);
//		#endif
	}

	virtual protected void HandleBegan(Vector2 t){
		Ray ray = Camera.main.ScreenPointToRay (t);
		RaycastHit rayHit;

		#if UNITY_EDITOR
		Debug.Log(t);
		#endif

		if (Physics.Raycast (ray, out rayHit)) {
			#if UNITY_EDITOR
			Debug.Log (rayHit.collider.gameObject.name);
			#endif
			InteractableObject curIntObject = rayHit.collider.GetComponent<InteractableObject> ();
			if (curIntObject) {
				currentSelectedObject = curIntObject;
			}
		} else {
			#if UNITY_EDITOR
			Debug.DrawRay (ray.origin, ray.direction, Color.red, 5.0f);
			#endif
		}
	}

	virtual protected void HandleMoved(Vector2 t,InteractableObject obj){
		if (obj == null && !bypassNoSelectedObject) {
			return;
		} else {

		}
	}

	virtual protected void HandleEnded(Vector2 t,InteractableObject obj){
		if (obj == null && !bypassNoSelectedObject) {
			return;
		} else {
			obj.InteractObject ();
		}
	}
}
