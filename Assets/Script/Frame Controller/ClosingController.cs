using UnityEngine;
using System.Collections;

public class ClosingController : AbstractFrame {
	public SFXProfile finishVO;

	float timeFlag;

	protected override void OnEnable ()
	{
		base.OnEnable ();
		timeFlag = startVO.clip.length + 1.5f;
	}

	protected override void Update ()
	{
		base.Update ();
		timeFlag -= Time.deltaTime;
		if (timeFlag <= 0.0f) {
			timeFlag = 99999.0f;
			AudioManager.instance.PlayVoiceOver (finishVO, 0.0f);
		}
	}
}
