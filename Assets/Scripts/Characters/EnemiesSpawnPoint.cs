using UnityEngine;

public class EnemiesSpawnPoint : MonoBehaviour {

	[SerializeField] private float radius;

	private Vector3 randomPosition => transform.position + (Vector3.one-Vector3.forward) * Random.Range(0f, 1f) * radius;
	
	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);
	}

	public void SpawnCharacter(StandardCharacter character) {
		character.transform.position = randomPosition;
	}
	
}