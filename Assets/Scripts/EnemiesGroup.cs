using UnityEngine;

public static class EnemiesGroup {

	private static int enemiesCount { get; set; }

	public static void AddCharacter() {
		enemiesCount++;
	}

	public static void RemoveCharacter() {
		enemiesCount--;
		if (enemiesCount == 0) 
			GameLoopEvents.EndRound();
		//Debug.Log("The end");
	}
	
}