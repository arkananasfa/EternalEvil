using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour {

	[SerializeField] private List<EnemiesSpawnPoint> spawners;
	[SerializeField] private RoundConfig roundConfig;
	[SerializeField] private StandardEnemiesFactory factory;

	private void OnEnable() {
		GameLoopEvents.OnRoundStarted += SpawnEnemies;
	}

	private void OnDisable() {
		GameLoopEvents.OnRoundStarted -= SpawnEnemies;
	}
	
	private void SpawnEnemies() {
		int powerLast = roundConfig.SumEnemiesPower;
		while (powerLast > 0) {
			int number = Random.Range(0, spawners.Count);
			StandardCharacter enemy;
			(enemy, powerLast) = factory.GetRandomCharacter(powerLast);
			spawners[number].SpawnCharacter(enemy);
		}
	}

}