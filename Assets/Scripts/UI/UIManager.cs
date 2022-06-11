using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	public bool DebugMode { get; set; }
	public static UIManager Instance;

	private void Awake() {
		Instance = this;
		DebugMode = Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer;
	}

	private void OnEnable() {
		GameLoopEvents.OnGameLost += ShowLoseScreen;
	}

	private void Start() {
		GameLoopEvents.GameStart();
	}

	public void ShowLoseScreen() {
		Debug.Log("You Lose");	
	}

	private void OnDisable() {
		GameLoopEvents.OnGameLost -= ShowLoseScreen;
	}

}