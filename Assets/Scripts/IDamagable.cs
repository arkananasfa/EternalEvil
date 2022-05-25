using UnityEngine;
using UnityEngine.Events;

public interface IDamagable {
	
	float Damage { get; set; }
	float Speed { get; set; }
	float LifeTime { get; set; }
	LayerMask LayersToInteract { get; set; }
	UnityEvent OnHit { get; set; }

}

public enum InGameLayers {
	Player = 6,
	PlayerBullet = 7,
	Enemy = 8,
	EnemyBullet = 9,
	Obstcle = 10
}