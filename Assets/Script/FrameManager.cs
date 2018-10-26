using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FrameManager : MonoBehaviour {
	[SerializeField]
	static AbstractFrame currentFrame;



	public List<AbstractFrame> frameList;
	int currentPage = 0;

	void Awake(){
		if (frameList.Count <= 0) {
			Debug.LogWarning ("No Frame Detected");
		}
	}

	void Start(){
		currentPage = 0;
		SetupFrame ();
	}

	public void SetupFrame(){
		currentFrame = frameList [currentPage];
		Camera.main.transform.position = new Vector3 (0.0f, 0.0f, -10.0f);

		foreach (AbstractFrame frame in frameList) {
			if (frame.Equals (currentFrame)) {
				frame.gameObject.SetActive (true);
			} else {
				frame.gameObject.SetActive (false);
			}
		}
	}

	public void NextPage(){
		if (currentPage >= frameList.Count - 1) {
			return;
		}
		currentPage++;

		SetupFrame ();
	}

	public void PrevPage(){
		if (currentPage <= 0) {
			return;
		}
		currentPage--;

		SetupFrame ();
	}

	public void HomePage(){
		currentPage = 0;

		SetupFrame ();
	}
}
