using UnityEngine;
using System.Collections;

public class MainMenuController : AbstractFrame {
	[SerializeField]
	Animator papanAnim;

	int papanStartTrigger;

	protected override void OnEnable ()
	{
		base.OnEnable ();

		if (papanAnim) {
			papanAnim.SetTrigger (papanStartTrigger);
		}
	}

	protected override void Awake ()
	{
		base.Awake ();
		papanStartTrigger = Animator.StringToHash ("StartTrigger");
	}

	protected override void Start ()
	{
		base.Start ();
	}

	protected override void Update ()
	{
		base.Update ();
	}
}
