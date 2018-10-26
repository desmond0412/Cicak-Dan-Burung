using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Frame5Controller : AbstractFrame {
	[SerializeField]
	List<GameObject> interactableObjectList;

	[SerializeField]
	GameObject text1,text2;

	public Frame5Pitput pitput;
	public SFXProfile objectiveVO,finishVO;

	float timeFlag;

	protected override void Awake ()
	{
		base.Awake ();
	}

	protected override void OnEnable ()
	{
		base.OnEnable ();

		timeFlag = startVO.clip.length + 1.5f;
		base.isFinish = false;

		foreach (GameObject g in interactableObjectList) {
			g.SetActive (true);
			g.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		}

		pitput.SetIdle ();

		text1.SetActive (true);
		text2.SetActive (false);
	}

	protected override void Update ()
	{
		base.Update ();
		timeFlag -= Time.deltaTime;
		if (timeFlag <= 0.0f && !base.isFinish) {
			timeFlag = 12.0f;
			AudioManager.instance.PlayVoiceOver (objectiveVO, 0.1f);
		}
	}

	public void setFinish(){
		base.isFinish = true;
		AudioManager.instance.PlayVoiceOver (finishVO, 0.0f);
		pitput.SetFly ();
		text1.SetActive (false);
		text2.SetActive (true);
	}
}
