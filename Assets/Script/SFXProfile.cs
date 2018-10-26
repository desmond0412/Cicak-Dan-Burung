using UnityEngine;
using System.Collections;

[System.Serializable]
public class SFXProfile{
	public AudioClip clip;

	[Range(0.0f,1.0f)]
	public float clipVolume = 1.0f;
}
