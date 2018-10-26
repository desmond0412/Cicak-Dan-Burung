using UnityEngine;
using System.Collections;

public class Frame4Controller : AbstractFrame {
	public Frame4Pitput pitput;
	public GameObject shootFired,firstText,endText;
	public SFXProfile shotSFX;
	public SFXProfile shotVO;
	public SFXProfile afterShotBGM;

	Vector3 worldPoint;

	public float pitputHorizontalSpeed = 1.5f,pitputVerticalSpeed = 1.5f;

	protected override void OnEnable ()
	{
		base.OnEnable ();

		base.isFinish = false;
		pitput.SetupPitput ();
		shootFired.SetActive (false);
		firstText.SetActive (true);
		endText.SetActive (false);
	}

	protected override void Update ()
	{
		base.Update ();
		Camera.main.transform.position = new Vector3 (Mathf.Max(Mathf.Min(pitput.transform.position.x,28.0f),0.0f), Camera.main.transform.position.y, Camera.main.transform.position.z);

		if (!pitput.isFrontLock && pitput.startMovement) {
			pitput.transform.Translate (Vector3.right * Time.deltaTime * pitputHorizontalSpeed, Space.World);
		}
	}

	protected override void HandleBegan (Vector2 t)
	{
		base.HandleBegan (t);

		pitput.startMovement = true;
	}

	protected override void HandleMoved (Vector2 t, InteractableObject obj)
	{
		base.HandleMoved (t, obj);

		worldPoint = Camera.main.ScreenToWorldPoint (t);

		if (worldPoint.y > pitput.transform.position.y + 0.25f && !pitput.isTopLock) {
			pitput.transform.Translate (Vector3.up * Time.deltaTime * pitputVerticalSpeed, Space.World);
		} else if (worldPoint.y< pitput.transform.position.y - 0.25f && !pitput.isBottomLock) {
			pitput.transform.Translate (Vector3.down * Time.deltaTime * pitputVerticalSpeed, Space.World);
		}
	}

	protected override void HandleEnded (Vector2 t, InteractableObject obj)
	{
		base.HandleEnded (t, obj);
	}

	public void SetFinishFrame(){
		pitput.SetFinish ();
		AudioManager.instance.PlaySFX (shotSFX, 0.0f);
		AudioManager.instance.PlayVoiceOver (shotVO, 0.3f);
		AudioManager.instance.PlayBGM (afterShotBGM, 0.75f);
		shootFired.SetActive (true);
		endText.SetActive (true);
		base.isFinish = true;
	}
}
