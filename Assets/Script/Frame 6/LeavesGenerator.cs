using UnityEngine;
using System.Collections;

public class LeavesGenerator : MonoBehaviour {
	public GameObject leavesPrefab;
	public Transform trashPool;
	public Transform leftEdge,rightEdge;

	public float leavesRate = 0.33f;

	float lastLeaf;

	void FixedUpdate(){
		if (Time.fixedTime > lastLeaf + (1.0f / leavesRate)) {
			lastLeaf = Time.fixedTime;

			GameObject go = Instantiate (leavesPrefab,
				Vector3.Lerp(leftEdge.position,rightEdge.position,Random.Range (0.0f, 1.0f)), 
					Quaternion.Euler(new Vector3(0.0f,0.0f,Random.Range(0.0f,360.0f)))) as GameObject;
			
			if (trashPool) {
				go.transform.SetParent (trashPool);
			}
		}
	}
}
