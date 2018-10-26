using UnityEngine;
using System.Collections;

public class Frame3Controller : AbstractFrame {
	public Transform pitput,cicak;

	int flyHash,idleHash;
	Vector3 cicakStartingPos,pitputStartingPos;

	public SFXProfile objectiveVO;
	float timeFlag;

	protected override void Awake ()
	{
		base.Awake ();

		cicakStartingPos = cicak.position;
		pitputStartingPos = pitput.position;
	}

	protected override void Start ()
	{
		base.Start ();

		flyHash = Animator.StringToHash ("FlyTrigger");
		idleHash = Animator.StringToHash ("IdleTrigger");
	}

	protected override void OnEnable(){
		base.OnEnable ();

		cicak.SetParent (transform);
		FindObjectOfType<Frame3Cicak> ().isLocked = false;

		cicak.position = cicakStartingPos;
		pitput.position = pitputStartingPos;

		cicak.localScale = Vector3.one;
		pitput.localScale = Vector3.one;

		timeFlag = startVO.clip.length + 1.5f;

		pitput.GetComponent<Animator> ().SetTrigger (idleHash);
		base.isFinish = false;
	}

	protected override void Update ()
	{
		base.Update ();

		timeFlag -= Time.deltaTime;
		if (timeFlag < 0.0f && !base.isFinish) {
			timeFlag += 15.0f;
			AudioManager.instance.PlayVoiceOver (objectiveVO, 0.3f);
		}
	} 

	protected override void HandleBegan (Vector2 t)
	{
		base.HandleBegan (t);
	}

	protected override void HandleMoved (Vector2 t, InteractableObject obj)
	{
		base.HandleMoved (t, obj);

		Frame3Cicak cicak = obj.GetComponent<Frame3Cicak> ();

		if (cicak && !cicak.isLocked) {
			cicak.transform.position = Camera.main.ScreenToWorldPoint(t);
			cicak.transform.position = new Vector3 (cicak.transform.position.x,
				cicak.transform.position.y,
				0.0f);
		}
	}

	protected override void HandleEnded (Vector2 t, InteractableObject obj)
	{
		base.HandleEnded (t, obj);

		Frame3Cicak cicak = obj.GetComponent<Frame3Cicak> ();

		if (cicak && cicak.isFrameTarget && !cicak.isLocked && cicak.transform.position.x > 0.95f && cicak.transform.position.x < 2.55f
		    && cicak.transform.position.y > -1.05f && cicak.transform.position.y < 0.3f) {

			cicak.transform.SetParent (pitput);
			cicak.isLocked = true;

			pitput.GetComponent<Animator> ().SetTrigger (flyHash);
		}
	}

	public void FinishScene(){
		base.isFinish = true;
	}
}
