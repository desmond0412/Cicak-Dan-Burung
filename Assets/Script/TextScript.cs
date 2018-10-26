using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TextScript : MonoBehaviour {
	MeshRenderer rend;

	public int sortOrder = 0;

	void Awake(){
		rend = GetComponent<MeshRenderer> ();
	}

	void Start(){
		if (!rend){
			Debug.LogWarning ("Renderer Not Attached");
		}
	}

	void Update(){
		rend.sortingOrder = sortOrder;
	}
}
