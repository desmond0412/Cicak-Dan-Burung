using UnityEngine;
using System.Collections;

public class Frame4Detector : MonoBehaviour {
	public enum DetectorType{
		Top,
		Bottom,
		Front
	}
		
	public DetectorType type;
	public Frame4Pitput pitput;
	public Frame4Controller levelController;

	void OnTriggerEnter(Collider col){
		Frame4Obstacle script = col.GetComponent<Frame4Obstacle> ();

		if (script) {
			if (!script.IsFinishLine) {
				switch (type) {
				case DetectorType.Top:
					pitput.isTopLock = true;
					break;
				case DetectorType.Front:
					pitput.isFrontLock = true;
					break;
				case DetectorType.Bottom:
					pitput.isBottomLock = true;
					break;
				}
			} else {
				levelController.SetFinishFrame ();
			}
		}
	}

	void OnTriggerExit(Collider col){
		if (col.GetComponent<Frame4Obstacle> ()) {
			switch (type) {
			case DetectorType.Top:
				pitput.isTopLock = false;
				break;
			case DetectorType.Front:
				pitput.isFrontLock = false;
				break;
			case DetectorType.Bottom:
				pitput.isBottomLock = false;
				break;
			}
		}
	}
}
