using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Frame6Controller : AbstractFrame {
	[SerializeField]
	List<GameObject> conversationList;
	[SerializeField]
	List<SFXProfile> VOList;

	int currentConv = 0;

	public Animator cicakAnim,pitputAnim;

	int isCicakBiasaHash,isCicakSenangHash,isCicakDiamHash;
	int isPitputTakutHash,isPitputSedihHash,isPitputSenangHash;

	protected override void Awake ()
	{
		base.Awake ();

		isCicakBiasaHash = Animator.StringToHash ("IsBiasa");
		isCicakSenangHash = Animator.StringToHash ("IsSenang");
		isCicakDiamHash = Animator.StringToHash ("IsDiam");

		isPitputTakutHash = Animator.StringToHash ("IsTakut");
		isPitputSedihHash = Animator.StringToHash ("IsSedih");
		isPitputSenangHash = Animator.StringToHash ("IsSenang");
	}

	protected override void OnEnable ()
	{
		base.OnEnable ();

		currentConv = 0;
		SetupFrame ();
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
			cicakAnim.SetBool (isCicakBiasaHash, true);
			cicakAnim.SetBool (isCicakDiamHash, false);
			cicakAnim.SetBool (isCicakSenangHash, false);

			pitputAnim.SetBool (isPitputTakutHash, true);
			pitputAnim.SetBool (isPitputSedihHash, false);
			pitputAnim.SetBool (isPitputSenangHash, false);
			break;
		case 1:
			cicakAnim.SetBool (isCicakBiasaHash, false);
			cicakAnim.SetBool (isCicakDiamHash, true);
			cicakAnim.SetBool (isCicakSenangHash, false);

			pitputAnim.SetBool (isPitputTakutHash, true);
			pitputAnim.SetBool (isPitputSedihHash, false);
			pitputAnim.SetBool (isPitputSenangHash, false);
			break;
		case 2:
			cicakAnim.SetBool (isCicakBiasaHash, false);
			cicakAnim.SetBool (isCicakDiamHash, true);
			cicakAnim.SetBool (isCicakSenangHash, false);

			pitputAnim.SetBool (isPitputTakutHash, false);
			pitputAnim.SetBool (isPitputSedihHash, true);
			pitputAnim.SetBool (isPitputSenangHash, false);
			break;
		case 3:
			cicakAnim.SetBool (isCicakBiasaHash, true);
			cicakAnim.SetBool (isCicakDiamHash, false);
			cicakAnim.SetBool (isCicakSenangHash, false);

			pitputAnim.SetBool (isPitputTakutHash, false);
			pitputAnim.SetBool (isPitputSedihHash, true);
			pitputAnim.SetBool (isPitputSenangHash, false);
			break;
		case 4:
			cicakAnim.SetBool (isCicakBiasaHash, true);
			cicakAnim.SetBool (isCicakDiamHash, false);
			cicakAnim.SetBool (isCicakSenangHash, false);

			pitputAnim.SetBool (isPitputTakutHash, false);
			pitputAnim.SetBool (isPitputSedihHash, false);
			pitputAnim.SetBool (isPitputSenangHash, true);
			break;
		case 5:
			cicakAnim.SetBool (isCicakBiasaHash, true);
			cicakAnim.SetBool (isCicakDiamHash, false);
			cicakAnim.SetBool (isCicakSenangHash, false);

			pitputAnim.SetBool (isPitputTakutHash, false);
			pitputAnim.SetBool (isPitputSedihHash, false);
			pitputAnim.SetBool (isPitputSenangHash, true);
			break;
		case 6:
			cicakAnim.SetBool (isCicakBiasaHash, false);
			cicakAnim.SetBool (isCicakDiamHash, false);
			cicakAnim.SetBool (isCicakSenangHash, true);

			pitputAnim.SetBool (isPitputTakutHash, false);
			pitputAnim.SetBool (isPitputSedihHash, false);
			pitputAnim.SetBool (isPitputSenangHash, true);
			break;
		default:
			cicakAnim.SetBool (isCicakBiasaHash, true);
			cicakAnim.SetBool (isCicakDiamHash, false);
			cicakAnim.SetBool (isCicakSenangHash, false);

			pitputAnim.SetBool (isPitputTakutHash, true);
			pitputAnim.SetBool (isPitputSedihHash, false);
			pitputAnim.SetBool (isPitputSenangHash, false);
			break;
		}
	}
}
