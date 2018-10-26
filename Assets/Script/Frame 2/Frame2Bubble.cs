using UnityEngine;
using System.Collections;

public class Frame2Bubble : MonoBehaviour {
	void Start () {
		iTween.ScaleFrom (this.gameObject, iTween.Hash ("scale", Vector3.one * 0.9f,
			"time", 1.5f,
			"easetype", iTween.EaseType.linear,
			"looptype", iTween.LoopType.pingPong));
	}
}
