using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance = null;

	AudioSource BGMManager = null;
	AudioSource VOManager = null;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		if (BGMManager == null) {
			BGMManager = this.gameObject.AddComponent<AudioSource> ();
			BGMManager.playOnAwake = false;
			BGMManager.loop = true;
			BGMManager.volume = 1.0f;
			BGMManager.Stop ();
		}

		if (VOManager == null) {
			VOManager = this.gameObject.AddComponent<AudioSource> ();
			VOManager.playOnAwake = false;
			VOManager.loop = false;
			VOManager.Stop ();
		}
	}

	public void PlayBGM(SFXProfile sfx,float switchTime){
		if (sfx.clip != BGMManager.clip && sfx.clip != null) {
			StartCoroutine (PlayBGMFade (sfx,switchTime));
		}
	}

	public void PlaySFX(SFXProfile sfx,float delayTime){
		if (sfx.clip != null) {
			StartCoroutine (PlaySFXCoroutine (sfx, delayTime));
		}
	}

	public void PlayVoiceOver(SFXProfile sfx,float switchTime){
		VOManager.Stop ();

		VOManager.clip = sfx.clip;
		VOManager.PlayDelayed (switchTime);
		VOManager.volume = sfx.clipVolume;
	}

	public void StopBGM(){
		BGMManager.Stop ();
	}

	public void StopVoiceOver(){
		VOManager.Stop ();
	}

	IEnumerator PlayBGMFade(SFXProfile sfx,float fadeDelay){
		float currVolume = BGMManager.volume;

		for (float f = 0.0f; f < fadeDelay / 2.0f; f += Time.deltaTime) {
			BGMManager.volume = Mathf.Clamp01( (1.0f - (f / (fadeDelay / 2.0f))) * currVolume );
			yield return null;
		}
		BGMManager.volume = 0.0f;
		BGMManager.Stop ();

		BGMManager.clip = sfx.clip;
		BGMManager.PlayDelayed (0.0f);
		for (float f = 0.0f; f < fadeDelay / 2.0f; f += Time.deltaTime) {
			BGMManager.volume = Mathf.Clamp01(f / (fadeDelay / 2.0f) * sfx.clipVolume);
			yield return null;
		}
		BGMManager.volume = sfx.clipVolume;
	}

	IEnumerator PlaySFXCoroutine(SFXProfile sfx, float delayTime){
		AudioSource go = this.gameObject.AddComponent<AudioSource> ();
		go.playOnAwake = false;
		go.Stop ();

		go.clip = sfx.clip;
		go.volume = sfx.clipVolume;
		go.PlayDelayed (delayTime);

		yield return new WaitForSeconds (sfx.clip.length + delayTime);
		Destroy (go);
	}

//	IEnumerator PlayVoiceOverCoroutine(AudioClip clip,float switchTime){
//	}
}
