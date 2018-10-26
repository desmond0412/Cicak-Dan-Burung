using UnityEngine;
using System.Collections;

public class Frame3PitputHandler : MonoBehaviour {
	public void FinishHandle(){
		FindObjectOfType<Frame3Controller> ().FinishScene ();
	}
}
