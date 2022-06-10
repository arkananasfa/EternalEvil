using UnityEngine;

public interface IAttackable {

	Transform Target { get; set; }
	float Damage { get; set; }
	float AttackRange { get; set; }
	float ReloadTime { get; set; }
	bool IsAttacking { get; }
	bool IsReloaded { get; }

	void Attack();

}