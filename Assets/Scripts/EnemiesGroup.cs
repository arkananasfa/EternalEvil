using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemiesGroup : MonoBehaviour {

	private List<StandardCharacter> enemiesList = new List<StandardCharacter>();

	public void AddCharacter(StandardCharacter character) {
		enemiesList.Add(character);
	}

	public void RemoveCharacter(StandardCharacter character) {
		enemiesList.Remove(character);
		if (enemiesList.Count == 0) 
			GameLoopEvents.EndRound();
	}

	private void OnEnable() {
		GameLoopEvents.OnGameLost += KillAllEnemies;
	}

	private void OnDisable() {
		GameLoopEvents.OnGameLost -= KillAllEnemies;
	}

	private void KillAllEnemies() {
		enemiesList.ForEach(e => Object.Destroy(e.gameObject));
		enemiesList.Clear();
	}
	
}