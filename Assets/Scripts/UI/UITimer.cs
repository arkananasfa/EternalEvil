using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour {

	[SerializeField] private RoundConfig roundConfig;
	[SerializeField] private StandardPerkChooseMenu perkChooseMenu;
	
	private TextMeshProUGUI textMeshPro;

	private void Awake() {
		textMeshPro = GetComponent<TextMeshProUGUI>();
		textMeshPro.enabled = false;
	}

	private void OnEnable() {
		GameLoopEvents.OnWeaponChosen += StartRoundTimer;
		GameLoopEvents.OnRoundEnded += EndRoundTimer;
	}
	
	private void OnDisable() {
		GameLoopEvents.OnWeaponChosen -= StartRoundTimer;
		GameLoopEvents.OnRoundEnded -= EndRoundTimer;
	}

	private void StartRoundTimer(AbstractWeapon weapon) {
		StartCoroutine(ToStartRoundTimer());
	}

	private IEnumerator ToStartRoundTimer() {
		textMeshPro.enabled = true;
		textMeshPro.text = "3";
		yield return new WaitForSeconds(1f);
		textMeshPro.text = "2";
		yield return new WaitForSeconds(1f);
		textMeshPro.text = "1";
		yield return new WaitForSeconds(1f);
		textMeshPro.text = "Start";
		GameLoopEvents.StartRound();
		yield return new WaitForSeconds(1f);
		textMeshPro.enabled = false;
	}

	private void EndRoundTimer() {
		StartCoroutine(Congrats());
	}

	private IEnumerator Congrats() {
		yield return new WaitForSeconds(0.5f);
		textMeshPro.enabled = true;
		textMeshPro.text = "Congrats!";
		yield return new WaitForSeconds(1f);
		textMeshPro.text = $"Round {roundConfig.RoundsNumber}";
		yield return new WaitForSeconds(1f);
		textMeshPro.enabled = false;
		perkChooseMenu.CreateMenu();
	}

}