using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Frame2Controller : AbstractFrame {
	[SerializeField]
	List<GameObject> conversationList;

	[SerializeField]
	List<SFXProfile> VOList;

	int currentConv = 0;

	int IsSadHash;

	public Animator cicak,pitput;


	protected override void Awake ()
	{
		base.Awake ();

	}

	protected override void OnEnable ()
	{
		base.OnEnable ();

		currentConv = 0;
		SetupFrame ();
	}

	protected override void Start ()
	{
		base.Start ();
		IsSadHash = Animator.StringToHash ("IsSad");
	}

	protected override void Update ()
	{
		base.Update ();
	}

	protected override void HandleEnded (Vector2 t, InteractableObject obj)
	{
		if (obj!=null && obj.isFrameTarget && currentConv < conversationList.Count-1) {
			currentConv++;

			SetupFrame ();
		}

		base.HandleEnded (t, obj);
	}

	void SetupFrame(){
		for (int i = 0; i < conversationList.Count; i++) {
			if (currentConv == i) {
				conversationList [i].SetActive (true);
				AudioManager.instance.PlayVoiceOver (VOList [i], 0.3f);
			} else {
				conversationList [i].SetActive (false);
			}
		}

		HandleExpression (currentConv);

		if (currentConv >= conversationList.Count - 1) {
			base.isFinish = true;
		} else {
			base.isFinish = false;
		}
	}

	void HandleExpression(int frame){
		switch (frame) {
		case 0:
			cicak.SetBool (IsSadHash, true);
			pitput.SetBool (IsSadHash, true);
			break;
		case 1:
			cicak.SetBool (IsSadHash, true);
			pitput.SetBool (IsSadHash, true);
			break;
		case 2:
			cicak.SetBool (IsSadHash, true);
			pitput.SetBool (IsSadHash, false);
			break;
		case 3:
			cicak.SetBool (IsSadHash, false);
			pitput.SetBool (IsSadHash, false);
			break;
		case 4:
			cicak.SetBool (IsSadHash, false);
			pitput.SetBool (IsSadHash, false);
			break;
		default:
			break;
		}
	}
}
