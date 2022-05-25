using UnityEngine;
using UnityEngine.Events;

public interface IWeapon {

	float Damage { get; set; }
	float BulletSpeed { get; set; }
	float ReloadTime { get; set; }
	bool IsReloaded { get; set; }
	float LifeTime { get; set; }
	GameObject BulletPrefab { get; set; }
	Transform BulletParent { get; set; }
	UnityEvent OnAttack { get; set; }
	UnityEvent OnPastAttack { get; set; }
	UnityEvent OnReload { get; set; }

	Vector2 GetBulletSpawnPosition ();
	void Attack();
	void Reload();
	float GetCorrectDamage();
	
}