using System;
using System.Collections.Generic;
using UnityEngine;

public class MobileControlPanel : MonoBehaviour {

	[SerializeField] private List<GameObject> ObjectsToHideInDebugMode;

	private void OnEnable() {
		ObjectsToHideInDebugMode.ForEach(go => go.SetActive(false));
		if (UIManager.Instance.DebugMode) return;
		GameLoopEvents.OnWeaponChosen += ShowObjects;
		GameLoopEvents.OnRoundEnded += HideObjects;
		GameLoopEvents.OnGameLost += HideObjects;
	}

	private void OnDisable() {
		GameLoopEvents.OnWeaponChosen -= ShowObjects;
		GameLoopEvents.OnRoundEnded -= HideObjects;
		GameLoopEvents.OnGameLost -= HideObjects;
	}

	private void ShowObjects(AbstractWeapon weapon) {
		Debug.Log("a");
		ObjectsToHideInDebugMode.ForEach(go => go.SetActive(true));
	}

	private void HideObjects() {
		ObjectsToHideInDebugMode.ForEach(go => go.SetActive(false));
	}
	

}